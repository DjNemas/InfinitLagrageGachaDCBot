using Discord.Commands;
using InfinitLagrageGachaDCBot.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace InfinitLagrageGachaDCBot.UI
{
    public class Gacha
    {
        private static readonly string backgroundPath = "./res/background/gacha_background.jpg";
        //private static readonly Bitmap backgroundImage2Rows = new Bitmap(Image.FromFile(backgroundPath), new Size(400, 200));
        //private static readonly Bitmap backgroundImage1Row = new Bitmap(Image.FromFile(backgroundPath), new Size(400, 100));
        private static readonly Bitmap backgroundImage = new Bitmap(Image.FromFile(backgroundPath), new Size(200, 100));
        public static List<Stream> GetProximaGacha10(SocketCommandContext context, PlayerAccount player)
        {
            // Carrier 0.3%, BattleCruiser 0.5%, Fighter 1%, Cruiser 1.2%, Corvette 1.5%, Destoyer 2.5%, Frigate 3.0%, TechPoints 90%
            int[] probability = new int[] {3, 5, 10, 12, 15, 25, 30, 900 }; // Based on 1000

            List<Ships> shipsResult = CheckShipType(probability, true);
            UpdatePlayerResult(shipsResult, player, context);
            return GenerateUIPicture(shipsResult);
        }

        public static List<Stream> GetSCoinGacha10(SocketCommandContext context, PlayerAccount player)
        {
            // Carrier 0.3%, BattleCruiser 0.5%, Fighter 1%, Cruiser 1.2%, Corvette 1.5%, Destoyer 2.5%, Frigate 3.0%, TechPoints 90%
            int[] probability = new int[] { 30, 50, 100, 120, 150, 250, 300}; // Based on 1000

            List<Ships> shipsResult = CheckShipType(probability, false);
            UpdatePlayerResult(shipsResult, player, context);
            return GenerateUIPicture(shipsResult);
        }

        private static List<Stream> GenerateUIPicture(List<Ships> shipsResult)
        {
            List<Stream> streamList = new List<Stream>();
            streamList.Add(Create400x200(shipsResult[0], shipsResult[1], shipsResult[2], shipsResult[3]));
            streamList.Add(Create400x200(shipsResult[4], shipsResult[5], shipsResult[6], shipsResult[7]));
            streamList.Add(Create400x100(shipsResult[8], shipsResult[9]));
            return streamList;
        }

        private static void UpdatePlayerResult(List<Ships> shipsResult, PlayerAccount player, SocketCommandContext context)
        {
            foreach (var result in shipsResult)
            {
                bool hasShip = false;
                PlayerShips playerShip = null;
                foreach (var playerShips in player.PlayerShipList)
                {

                    if (playerShips.ShipName == result.ShipName)
                    {
                        hasShip = true;
                        playerShip = playerShips;
                    }
                }
                if (hasShip)
                {
                    playerShip.IncreasShipCount();
                    playerShip.UpdateCountDB();
                }
                else
                {
                    PlayerShips newShip = new PlayerShips(context.User.Id, context.Guild.Id, result.ShipName, result.ShipType);
                    player.PlayerShipList.Add(newShip);
                    newShip.InsertIntoDB();
                }
            }
        }

        private static List<Ships> CheckShipType(int[] Probability, bool hasTechPoints)
        {
            List<Ships> shipsResult = new List<Ships>();

            int maxProbability = 0;
            foreach (var item in Probability)
                maxProbability += item;

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int currentProbabilityCheck = Probability[0];
                int rndNumber = rnd.Next(0, maxProbability);

                // Carrier
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListCarrier[rnd.Next(0, Ships.shipListCarrier.Count)]);
                }
                // BattleCruiser
                currentProbabilityCheck += Probability[1];
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListBattlecruiser[rnd.Next(0, Ships.shipListBattlecruiser.Count)]);
                }
                // Fighter
                currentProbabilityCheck += Probability[2];
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListFighter[rnd.Next(0, Ships.shipListFighter.Count)]);
                }
                // Cruiser
                currentProbabilityCheck += Probability[3];
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListCruiser[rnd.Next(0, Ships.shipListCruiser.Count)]);
                }
                // Corvette
                currentProbabilityCheck += Probability[4];
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListCorvettes[rnd.Next(0, Ships.shipListCorvettes.Count)]);
                }
                // Destoyer
                currentProbabilityCheck += Probability[5];
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListDestroyer[rnd.Next(0, Ships.shipListDestroyer.Count)]);
                }
                // Frigates
                currentProbabilityCheck += Probability[6];
                if (rndNumber < currentProbabilityCheck)
                {
                    shipsResult.Add(Ships.shipListFrigates[rnd.Next(0, Ships.shipListFrigates.Count)]);
                }
                if (hasTechPoints)
                {
                    // Techpoints
                    currentProbabilityCheck += Probability[7];
                    if (rndNumber < currentProbabilityCheck)
                    {
                        shipsResult.Add(Ships.shipListTechpoints[rnd.Next(0, Ships.shipListTechpoints.Count)]);
                    }
                }
            }
            return shipsResult;
        }

        private static Stream Create400x200(Ships ship1, Ships ship2, Ships ship3, Ships ship4)
        {
            MemoryStream ms = new MemoryStream();
            int shipWidth = 200;
            int shipHeight = 100;
            int shipTPWidth = 80;
            int shipTPHeight = 100;
            bool s1TP = false;
            bool s2TP = false;
            bool s3TP = false;
            bool s4TP = false;

            // Check if Techpoint
            if (ship1.ShipType == ShipType.Techpoints)
                s1TP = true;
            if (ship2.ShipType == ShipType.Techpoints)
                s2TP = true;
            if (ship3.ShipType == ShipType.Techpoints)
                s3TP = true;
            if (ship4.ShipType == ShipType.Techpoints)
                s4TP = true;

            using (Bitmap s1 = new Bitmap(ship1.ShipImage, s1TP ? new Size(shipTPWidth, shipTPHeight) : new Size(shipWidth, shipHeight)))
            {
                using (Bitmap s2 = new Bitmap(ship2.ShipImage, s2TP ? new Size(shipTPWidth, shipTPHeight) : new Size(shipWidth, shipHeight)))
                {
                    using (Bitmap s3 = new Bitmap(ship3.ShipImage, s3TP ? new Size(shipTPWidth, shipTPHeight) : new Size(shipWidth, shipHeight)))
                    {
                        using (Bitmap s4 = new Bitmap(ship4.ShipImage, s4TP ? new Size(shipTPWidth, shipTPHeight) : new Size(shipWidth, shipHeight)))
                        {
                            using (Bitmap combined = new Bitmap(400, 200, PixelFormat.Format24bppRgb))
                            {
                                using (Graphics g = Graphics.FromImage(combined))
                                {
                                    // Background fist
                                    //g.DrawImage(backgroundImage2Rows, new Point(0,0));
                                    g.DrawImage(backgroundImage, new Point(0, 0));
                                    g.DrawImage(backgroundImage, new Point(200, 0));
                                    g.DrawImage(backgroundImage, new Point(0, 100));
                                    g.DrawImage(backgroundImage, new Point(200, 100));

                                    g.DrawImage(s1, s1TP ? new Point(60, 0) : new Point(0, 0));
                                    g.DrawImage(s2, s2TP ? new Point(260, 0) : new Point(200, 0));
                                    g.DrawImage(s3, s3TP ? new Point(60, 100) : new Point(0, 100));
                                    g.DrawImage(s4, s4TP ? new Point(260, 100) : new Point(200, 100));
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

            int shipTPWidth = 80;
            int shipTPHeight = 100;
            bool s1TP = false;
            bool s2TP = false;

            // Check if Techpoint
            if (ship1.ShipType == ShipType.Techpoints)
                s1TP = true;
            if (ship2.ShipType == ShipType.Techpoints)
                s2TP = true;

            using (Bitmap s1 = new Bitmap(ship1.ShipImage, s1TP ? new Size(shipTPWidth, shipTPHeight) : new Size(shipWidth, shipHeight)))
            {
                using (Bitmap s2 = new Bitmap(ship2.ShipImage, s2TP ? new Size(shipTPWidth, shipTPHeight) : new Size(shipWidth, shipHeight)))
                {
                    using (Bitmap combined = new Bitmap(400, 100, PixelFormat.Format24bppRgb))
                    {
                        using (Graphics g = Graphics.FromImage(combined))
                        {
                            // Background fist
                            //g.DrawImage(backgroundImage2Rows, new Point(0,0));
                            g.DrawImage(backgroundImage, new Point(0, 0));
                            g.DrawImage(backgroundImage, new Point(200, 0));

                            g.DrawImage(s1, s1TP ? new Point(60, 0) : new Point(0, 0));
                            g.DrawImage(s2, s2TP ? new Point(260, 0) : new Point(200, 0));
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
