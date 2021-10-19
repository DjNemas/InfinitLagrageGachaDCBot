using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using static InfinitLagrageGachaDCBot.Files.Log;

namespace InfinitLagrageGachaDCBot.Files
{
    public class DB
    {
        private static readonly string directory = "database";
        private static readonly string fileName = "db.sqlite";
        protected static readonly string path = directory + "/" + fileName;
        public static void CreateDBFile()
        {
            if (!Directory.Exists(directory))
                try
                {
                    Directory.CreateDirectory(directory);
                    string log = "Folder " + directory + " created!";
                    Console.WriteLine(log);
                    LogMain(log);
                }
                catch (Exception e)
                {
                    string log = "Folder " + directory + " could not be created.\n" + e;
                    Console.WriteLine(log);
                    LogMain(log, LogLevel.Error);
                }

            if (!File.Exists(path))
                try
                {
                    SQLiteConnection.CreateFile(path);
                    string log = "Database File " + fileName + " created!";
                    Console.WriteLine(log);
                    LogMain(log);
                }
                catch (Exception e)
                {
                    string log = "Database File " + fileName + " could not be created.\n" + e;
                    Console.WriteLine(log);
                    LogMain(log, LogLevel.Error);
                }
        }
    }
}
