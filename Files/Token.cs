using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InfinitLagrageGachaDCBot
{
    public class Token
    {
        private static readonly string directory = "config";
        private static readonly string fileName = "token.txt";
        private static readonly string path = directory + "/" + fileName;
        public static string GetToken()
        {
            string[] lines = File.ReadAllLines(path);
            if (lines is null || lines.Length <= 0)
                return "0";
            return lines[0];
        }

        public static void CreateTokenFile()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(path))
                File.Create(path).Close();
        }
    }
}
