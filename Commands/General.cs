using Discord;
using Discord.Commands;
using Discord.WebSocket;
using InfinitLagrageGachaDCBot.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitLagrageGachaDCBot
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong!");
        }

        [Command("profil")]
        public async Task Profil(SocketUser u = null)
        {
            SocketGuildUser user = u as SocketGuildUser;
            PlayerAccount player = PlayerAccount.GetPlayerFromDB(user == null ? Context.User.Id : user.Id, user == null ? Context.Guild.Id : user.Guild.Id);
            if (player == null && user == null)
            {
                await ReplyAsync($"{Context.User.Username} you don't have a Profil on this Server." +
                    $" Please create one first with `!create`");
                return;
            }
            else if (player == null)
            {
                await ReplyAsync($"{Context.User.Username} this player doesn't have a profil on this server.");
                return;
            }

            using (Stream stream = InfinitLagrageGachaDCBot.Profil.CreateProfilBanner(PlayerAccount.GetAvatarImage(user == null ? Context.User.GetAvatarUrl(ImageFormat.Png) : user.GetAvatarUrl(ImageFormat.Png)), player))
            {
                await Context.Channel.SendFileAsync(stream, "profilebanner.png");
            }
        }

        [Command("Create")]
        public async Task Create()
        {
            PlayerAccount player = PlayerAccount.GetPlayerFromDB(Context.User.Id, Context.Guild.Id);
            if (player != null)
            {
                await ReplyAsync($"{Context.User.Username} you already have a Account on this Server!");
                return;
            }
            else
            {
                player = new PlayerAccount(
                    discordAccountName: Context.User.Username,
                    discordAccountID: Context.User.Id,
                    discordGuildID: Context.Guild.Id,
                    proxima: 1500,
                    ueCoin: 100000,
                    sCoin: 0,
                    ueCoinChestLimit: 2
                    );
                player.CreatePlayerAccount(player);
                await ReplyAsync($"{Context.User.Username} you have a Profil now! Check it with `!profil`.");
            }
        }

        [Command("proxima")]
        public async Task Proxima()
        {
            PlayerAccount player = PlayerAccount.GetPlayerFromDB(Context.User.Id, Context.Guild.Id);
            if (player == null)
            {
                await ReplyAsync(Context.User.Mention + " You don't have a Profil here. Please create one first!");
                return;
            }
            else
            {
                if (player.Proxima < 150)
                {
                    await ReplyAsync(Context.User.Mention + " You don't have enough Proxima!");
                    return;
                }

                player.ReduceProxima(150);
                player.UpdateProximaDB();

                List<Stream> streamList = UI.Gacha.GetProximaGacha10(Context, player);
                await ReplyAsync(Context.User.Mention + " You pulled this!");
                await Context.Channel.SendFileAsync(streamList[0], "result1.png");
                await Context.Channel.SendFileAsync(streamList[1], "result2.png");
                await Context.Channel.SendFileAsync(streamList[2], "result3.png");
                streamList = null;
            }
        }

        [Command("gachainfo")]
        public async Task GachaInfo()
        {
            EmbedBuilder emBuilder = new EmbedBuilder();
            emBuilder.Title = "Gacha Info";
            emBuilder.Color = Color.Orange;
            // Generel Commands
            emBuilder.AddField($"Proxima Chest", "Pull a proxima chest x10 for 150 proxima.");
            emBuilder.AddField($"Drop Rate Proxima", "Carrier 0.3%, BattleCruiser 0.5%, Fighter 1%, Cruiser 1.2%, Corvette 1.5%, Destoyer 2.5%, Frigate 3.0%, TechPoints 90%.", true);


            await ReplyAsync(embed: emBuilder.Build());
        }

        [Command("commands")]
        public async Task Commands()
        {
            SQLiteCommand cmd = DB.CreateCommand();
            cmd.CommandText = "SELECT prefix FROM GuildConfig WHERE GuildID = @GuildID";
            cmd.Parameters.AddWithValue("@GuildID", Context.Guild.Id);
            SQLiteDataReader reader = cmd.ExecuteReader();
            string prefix = "";
            if (reader.HasRows)
                while (reader.Read())
                    prefix = reader.GetString(0);

            EmbedBuilder emBuilder = new EmbedBuilder();
            emBuilder.Title = "Commands List";
            emBuilder.Color = Color.Orange;

            // Generel Commands
            emBuilder.AddField($"{prefix}profil", "Shows you profil.");
            emBuilder.AddField($"{prefix}profil <@user>", "Shows the profil of @user.");
            emBuilder.AddField($"{prefix}create", "Creates a profil on this server if not exist.");
            emBuilder.AddField($"{prefix}proxima", "Use your Proxima to pull Proxima Chest.");
            emBuilder.AddField($"{prefix}gachainfo", "Shows information about gacha.");

            // Owner Commands
            emBuilder.AddField($"{prefix}prefix <character> (Owner Only)", "Change the Prefix for this Server.");
            emBuilder.AddField($"{prefix}channelid <channel> (Owner Only)", "Changes the channel the bot is listens to.");
            await ReplyAsync(embed: emBuilder.Build());
        }
    }
}
