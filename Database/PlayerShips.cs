using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfinitLagrageGachaDCBot.Files.Log;

namespace InfinitLagrageGachaDCBot.Database
{
    public class PlayerShips
    {
        private int ID;
        public ulong DiscordAccountID { get; private set; }
        public ulong DiscordGuildID { get; private set; }
        public ShipName ShipName { get; private set; }
        public ShipType ShipType { get; private set; }

        public int Count { get; private set; }

        private PlayerShips() { }
        public PlayerShips(ulong discordAccountID, ulong discordGuildID, ShipName shipName, ShipType shipType)
        {
            this.DiscordAccountID = discordAccountID;
            this.DiscordGuildID = discordGuildID;
            this.ShipName = shipName;
            this.ShipType = shipType;
            this.Count = 1;
        }

        /// <summary>
        /// Increase Ship Count + 1
        /// </summary>
        public void IncreasShipCount()
        {
            this.Count++;
        }
        public void InsertIntoDB()
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = "INSERT INTO PlayerShips (DiscordAccountID, DiscordGuildID, ShipName, ShipType, Count) " +
                    "VALUES(@DiscordAccountID, @DiscordGuildID, @ShipName, @ShipType, @Count);";
                com.Parameters.AddWithValue("@DiscordAccountID", this.DiscordAccountID);
                com.Parameters.AddWithValue("@DiscordGuildID", this.DiscordGuildID);
                com.Parameters.AddWithValue("@ShipName", this.ShipName);
                com.Parameters.AddWithValue("@ShipType", this.ShipType);
                com.Parameters.AddWithValue("@Count", this.Count);
                com.ExecuteNonQuery();
            }
        }

        public void UpdateCountDB()
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = "UPDATE PlayerShips SET Count = @Count " +
                    "WHERE DiscordAccountID = @DiscordAccountID AND " +
                    "DiscordGuildID = @DiscordGuildID AND " +
                    "ShipName = @ShipName";
                com.Parameters.AddWithValue("@Count", this.Count);
                com.Parameters.AddWithValue("@DiscordAccountID", this.DiscordAccountID);
                com.Parameters.AddWithValue("@DiscordGuildID", this.DiscordGuildID);
                com.Parameters.AddWithValue("@ShipName", (int)this.ShipName);
                com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets PlayerShips From Database
        /// </summary>
        /// <param name="discordAccountID">Players Discord Account ID</param>
        /// <returns>PlayerShips object or null if not exist</returns>
        public static List<PlayerShips> GetPlayerShipsFromDB(ulong discordAccountID, ulong discordGuildID)
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = "SELECT * FROM PlayerShips " +
                    "WHERE DiscordAccountID = @DiscordAccountID AND DiscordGuildID = @DiscordGuildID";
                com.Parameters.AddWithValue("@DiscordAccountID", discordAccountID);
                com.Parameters.AddWithValue("@DiscordGuildID", discordGuildID);
                SQLiteDataReader reader = com.ExecuteReader();
                List<PlayerShips> playerShipList = null;
                if (reader.HasRows)
                {
                    int count = 0;
                    playerShipList = new List<PlayerShips>();
                    while(reader.Read())
                    {
                        PlayerShips playerShip = new PlayerShips();
                        playerShip.ID = reader.GetInt32(0);
                        playerShip.DiscordAccountID = Convert.ToUInt64(reader.GetInt64(1));
                        playerShip.DiscordGuildID = Convert.ToUInt64(reader.GetInt64(2));
                        playerShip.ShipName = (ShipName)reader.GetInt32(3);
                        playerShip.ShipType = (ShipType)reader.GetInt32(4);
                        playerShip.Count = reader.GetInt32(5);
                        playerShipList.Add(playerShip);
                    }
                    return playerShipList;
                }
                return playerShipList;
            }
        }

        public static void CreateTable()
        {
            using (SQLiteCommand com = DB.CreateCommand())
            {
                com.CommandText = @"CREATE TABLE IF NOT EXISTS ""PlayerShips"" (
                                ""ID"" INTEGER NOT NULL UNIQUE,
                                ""DiscordAccountID""   INTEGER NOT NULL,
                                ""DiscordGuildID""   INTEGER NOT NULL,
                                ""ShipName"" INTEGER NOT NULL,
                                ""ShipType"" INTEGER NOT NULL,
                                ""Count"" INTEGER NOT NULL,
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
            }
        }
    }
}
