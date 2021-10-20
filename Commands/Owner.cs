using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.Data.SQLite;
using Discord.WebSocket;

namespace InfinitLagrageGachaDCBot.Commands
{
    public class Owner : ModuleBase<SocketCommandContext>
    {
        [Command("prefix")]
        [RequireOwner]
        public async Task Prefix(char c)
        {
            using (SQLiteCommand com = Database.DB.CreateCommand())
            {
                com.CommandText = "UPDATE GuildConfig SET Prefix = @Prefix WHERE GuildID = @GuildID";
                com.Parameters.AddWithValue("@Prefix", c.ToString());
                com.Parameters.AddWithValue("GuildID", Context.Guild.Id);
                com.ExecuteNonQuery();
            }
            await ReplyAsync("Prefix updated!");
        }

        [Command("channelid")]
        [RequireOwner]
        public async Task ChannelID(SocketGuildChannel channel)
        {
            using (SQLiteCommand com = Database.DB.CreateCommand())
            {
                com.CommandText = "UPDATE GuildConfig SET ChannelID = @ChannelID WHERE GuildID = @GuildID";
                com.Parameters.AddWithValue("@ChannelID", channel.Id);
                com.Parameters.AddWithValue("GuildID", Context.Guild.Id);
                com.ExecuteNonQuery();
            }
            await ReplyAsync("Channel updated!");
        }
    }
}
