using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfinitLagrageGachaDCBot.Files.Log;

namespace InfinitLagrageGachaDCBot.DiscordEvents
{
    public class DCEvents
    {
        private readonly DiscordSocketClient _client;

        public DCEvents(DiscordSocketClient client)
        {
            _client = client;
            _client.GuildAvailable += GuildAvailable;
        }

        private Task GuildAvailable(SocketGuild guild)
        {
            using (SQLiteCommand com = Database.DB.CreateCommand())
            {
                com.CommandText = @"SELECT GuildID FROM GuildConfig WHERE GuildID = @GuildID";
                com.Parameters.AddWithValue("@GuildID", guild.Id);
                object result = com.ExecuteScalar();
                if (result == null)
                {
                    com.CommandText = "INSERT INTO GuildConfig (Prefix, GuildID) VALUES (@Prefix, @GuildID)";
                    com.Parameters.AddWithValue("@Prefix", "!");
                    com.Parameters.AddWithValue("@GuildID", guild.Id);
                    com.ExecuteNonQuery();
                    string str = "Guild Config for " + guild.Name + " created.";
                    Console.WriteLine(str);
                    LogMain(str);
                }
            };
            return Task.CompletedTask;
        }
    }
}
