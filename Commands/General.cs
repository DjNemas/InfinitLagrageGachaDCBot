using Discord;
using Discord.Commands;
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

        [Command("Profil")]
        public async Task Profil()
        {
            PlayerAccount player = PlayerAccount.GetPlayerFromDB(Context.User.Id, Context.Guild.Id);
            if (player == null)
            {
                await ReplyAsync($"{Context.User.Username} you don't have a Profil on this Server." +
                    $" Please create one first with `!create`");
                return;
            }

            using (Stream stream = InfinitLagrageGachaDCBot.Profil.CreateProfilBanner(PlayerAccount.GetAvatarImage(Context.User.GetAvatarUrl(ImageFormat.Png)), player))
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

        [Command("test10")]
        public async Task Test10()
        {
            PlayerAccount player = PlayerAccount.GetPlayerFromDB(Context.User.Id, Context.Guild.Id);
            if (player == null)
            {
                await ReplyAsync(Context.User.Username + " You don't have a Profil here. Please create one first!");
                return;
            }
            else
            {
                List<Stream> streamList = UI.Gacha.GetTestGacha10(Context, player);
                await ReplyAsync(Context.User.Mention + " You pulled this!");
                await Context.Channel.SendFileAsync(streamList[0], "result1.png");
                await Context.Channel.SendFileAsync(streamList[1], "result2.png");
                await Context.Channel.SendFileAsync(streamList[2], "result3.png");
                streamList = null;
            }
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
            emBuilder.AddField($"{prefix}create", "Creates a profil on this server if not exist.");

            // Owner Commands
            emBuilder.AddField($"{prefix}prefix <character> (Owner Only)", "Change the Prefix for this Server.");
            emBuilder.AddField($"{prefix}channelid <channel> (Owner Only)", "Changes the channel the bot is listens to.");
            await ReplyAsync(embed: emBuilder.Build());
        }
    }
}
