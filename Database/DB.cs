using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace InfinitLagrageGachaDCBot.Database
{
    public class DB : Files.DB
    {
        private static readonly string dbConString = @"Data Source="+ path +";Version=3";
        private static SQLiteConnection con;

        public static SQLiteCommand CreateCommand()
        {
            con = new SQLiteConnection(dbConString);
            con.Open();
            return con.CreateCommand();
        }
    }
}
