﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static InfinitLagrageGachaDCBot.Files.Log;

namespace InfinitLagrageGachaDCBot.Database
{
    public class PlayerAccount
    {
        private int ID;
        public string discordAccountName { get; private set; }
        private ulong discordAccountID;
        private ulong discordGuildID;
        public int proxima { get; private set; }
        public int ueCoin { get; private set; }
        public int sCoin { get; private set; }
        public int ueCoinChestLimit { get; private set; }

        public static void CreateTable()
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = @"CREATE TABLE IF NOT EXISTS ""PlayerAccount"" (
                                ""ID"" INTEGER NOT NULL UNIQUE,
                                ""DiscordAccountName""   TEXT NOT NULL,
                                ""DiscordAccountID""   INTEGER NOT NULL,
                                ""DiscordGuildID""   INTEGER NOT NULL,
                                ""Proxima""   INTEGER,
                                ""UECoin""   INTEGER,
                                ""SCoin""   INTEGER,
                                ""UECoinChestLimit""   INTEGER,
                                PRIMARY KEY(""ID"" AUTOINCREMENT)
                                );";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string str = "Table PlayerAccounts could not be created!\n" + e;
                    Console.WriteLine(str);
                    LogMain(str);
                }
            };
        }

        public PlayerAccount(ulong discordAccountID, ulong discordGuildID)
        {
            this.discordAccountID = discordAccountID;
            this.discordGuildID = discordGuildID;
        }

        public PlayerAccount(string discordAccountName, ulong discordAccountID, ulong discordGuildID, int proxima, int ueCoin, int sCoin, int ueCoinChestLimit)
        {
            this.discordAccountName = discordAccountName;
            this.discordAccountID = discordAccountID;
            this.discordGuildID = discordGuildID;
            this.proxima = proxima;
            this.ueCoin = ueCoin;
            this.sCoin = sCoin;
            this.ueCoinChestLimit = ueCoinChestLimit;
        }

        private PlayerAccount() { }

        /// <summary>
        /// Return the play From Database
        /// </summary>
        /// <param name="discordAccountID"> Users DiscordAccountID</param>
        /// <param name="discordGuildID">Users DiscordGuildID</param>
        /// <returns>PlayerAccout or null when not exist</returns>
        public static PlayerAccount GetPlayerFromDB(ulong discordAccountID, ulong discordGuildID)
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                PlayerAccount player = null;
                com.CommandText = "SELECT * FROM PlayerAccount WHERE DiscordAccountID = @DiscordAccountID AND DiscordGuildID = @DiscordGuildID";
                com.Parameters.AddWithValue("@DiscordAccountID", discordAccountID);
                com.Parameters.AddWithValue("@DiscordGuildID", discordGuildID);
                SQLiteDataReader reader = null;
                reader = com.ExecuteReader();
                if (!reader.HasRows)
                    return player;
                
                while(reader.Read())
                {
                    player = new PlayerAccount() {
                        ID = reader.GetInt32(0),
                        discordAccountName = reader.GetString(1),
                        discordAccountID = Convert.ToUInt64(reader.GetInt64(2)),
                        discordGuildID = Convert.ToUInt64(reader.GetInt64(3)),
                        proxima = reader.GetInt32(4),
                        ueCoin = reader.GetInt32(5),
                        sCoin = reader.GetInt32(6),
                        ueCoinChestLimit = reader.GetInt32(7)
                    };
                }
                return player;
            }
        }

        public void CreatePlayerAccount(PlayerAccount player)
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = "INSERT INTO PlayerAccount (DiscordAccountName, DiscordAccountID, DiscordGuildID, Proxima, UECoin, SCoin, UECoinChestLimit) " +
                    "VALUES(@DiscordAccountName, @DiscordAccountID, @DiscordGuildID, @Proxima, @UECoin, @SCoin, @UECoinChestLimit);";
                com.Parameters.AddWithValue("@DiscordAccountName", player.discordAccountName);
                com.Parameters.AddWithValue("@DiscordAccountID", player.discordAccountID);
                com.Parameters.AddWithValue("@DiscordGuildID", player.discordGuildID);
                com.Parameters.AddWithValue("@Proxima", player.proxima);
                com.Parameters.AddWithValue("@UECoin", player.ueCoin);
                com.Parameters.AddWithValue("@SCoin", player.sCoin);
                com.Parameters.AddWithValue("@UECoinChestLimit", player.ueCoinChestLimit);
                com.ExecuteNonQuery();
            }
        }

        public static Image GetAvatarImage(string avatarURL)
        {
            using (WebClient client = new WebClient())
            {
                return Image.FromStream(client.OpenRead(new Uri(avatarURL)));
            }
        }
    }
}