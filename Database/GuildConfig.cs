using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using static InfinitLagrageGachaDCBot.Files.Log;

namespace InfinitLagrageGachaDCBot.Database
{
    public class GuildConfig
    {
        public int ID;
        public char Prefix;
        public ulong GuildID;

        public static void CreateTable()
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = @"CREATE TABLE IF NOT EXISTS ""GuildConfig"" (
                                ""ID"" INTEGER NOT NULL UNIQUE,
                                ""Prefix""    TEXT NOT NULL,
                                ""GuildID""   INTEGER NOT NULL UNIQUE,
                                ""ChannelID""   INTEGER NOT NULL UNIQUE,
                                PRIMARY KEY(""ID"" AUTOINCREMENT)
                                );";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string str = "Table GuildConfig could not be created!\n" + e;
                    Console.WriteLine(str);
                    LogMain(str);
                }
            };
        }
    }
}
