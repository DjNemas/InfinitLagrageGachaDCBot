using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.Data.SQLite;

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
            await Context.Channel.SendMessageAsync("Prefix geupdated!");
        }
    }
}
