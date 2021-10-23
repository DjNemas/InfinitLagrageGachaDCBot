using InfinitLagrageGachaDCBot.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitLagrageGachaDCBot.UI
{
    public class Gacha
    {
        public static List<Stream> GetTestGacha10()
        {
            List<Ships> shipsResult = new List<Ships>();
            
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int randomNumber = rnd.Next(0, Ships.shipList.Count);
                if (randomNumber == 0)
                {
                    shipsResult.Add(Ships.shipList[0]);
                }
                if (randomNumber == 1)
                {
                    shipsResult.Add(Ships.shipList[1]);
                }
                if (randomNumber == 2)
                {
                    shipsResult.Add(Ships.shipList[2]);
                }
                if (randomNumber == 3)
                {
                    shipsResult.Add(Ships.shipList[3]);
                }
                if (randomNumber == 4)
                {
                    shipsResult.Add(Ships.shipList[4]);
                }
                if (randomNumber == 5)
                {
                    shipsResult.Add(Ships.shipList[5]);
                }
                if (randomNumber == 6)
                {
                    shipsResult.Add(Ships.shipList[6]);
                }
                if (randomNumber == 7)
                {
                    shipsResult.Add(Ships.shipList[7]);
                }
                if (randomNumber == 8)
                {
                    shipsResult.Add(Ships.shipList[8]);
                }
            }

            List<Stream> streamList = new List<Stream>();
            streamList.Add(Create400x200(shipsResult[0], shipsResult[1], shipsResult[2], shipsResult[3]));
            streamList.Add(Create400x200(shipsResult[4], shipsResult[5], shipsResult[6], shipsResult[7]));
            streamList.Add(Create400x100(shipsResult[8], shipsResult[9]));
            return streamList;
        }

        private static Stream Create400x200(Ships ship1, Ships ship2, Ships ship3, Ships ship4)
        {
            MemoryStream ms = new MemoryStream();
            int shipWidth = 200;
            int shipHeight = 100;
            using (Bitmap s1 = new Bitmap(ship1.shipImage, new Size(shipWidth, shipHeight)))
            {
                using (Bitmap s2 = new Bitmap(ship2.shipImage, new Size(shipWidth, shipHeight)))
                {
                    using (Bitmap s3 = new Bitmap(ship3.shipImage, new Size(shipWidth, shipHeight)))
                    {
                        using (Bitmap s4 = new Bitmap(ship4.shipImage, new Size(shipWidth, shipHeight)))
                        {
                            using (Bitmap combined = new Bitmap(400, 200))
                            {
                                using (Graphics g = Graphics.FromImage(combined))
                                {
                                    g.DrawImage(s1, new Point(0, 0));
                                    g.DrawImage(s2, new Point(200, 0));
                                    g.DrawImage(s3, new Point(0, 100));
                                    g.DrawImage(s4, new Point(200, 100));
                                    g.Save();
                                    combined.Save(ms, ImageFormat.Png);
                                    ms.Position = 0;
                                    return ms;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static Stream Create400x100(Ships ship1, Ships ship2)
        {
            MemoryStream ms = new MemoryStream();
            int shipWidth = 200;
            int shipHeight = 100;
            using (Bitmap s1 = new Bitmap(ship1.shipImage, new Size(shipWidth, shipHeight)))
            {
                using (Bitmap s2 = new Bitmap(ship2.shipImage, new Size(shipWidth, shipHeight)))
                {
                    using (Bitmap combined = new Bitmap(400, 100))
                    {
                        using (Graphics g = Graphics.FromImage(combined))
                        {
                            g.DrawImage(s1, new Point(0, 0));
                            g.DrawImage(s2, new Point(200, 0));
                            g.Save();
                            combined.Save(ms, ImageFormat.Png);
                            ms.Position = 0;
                            return ms;
                        }
                    }
                }
            }
        }
    }
}
