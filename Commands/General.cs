using Discord;
using Discord.Commands;
using InfinitLagrageGachaDCBot.Database;
using System;
using System.Collections.Generic;
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
    }
}
