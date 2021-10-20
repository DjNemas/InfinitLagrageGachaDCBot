using InfinitLagrageGachaDCBot.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitLagrageGachaDCBot
{
    public class Profil
    {
        private static readonly string backgroundPath = "./res/background/grey_background_profile2.png";
        private static readonly string ueCoinPath = "./res/icon/ueCoin.png";
        private static readonly string sCoinPath = "./res/icon/sCoin.png";
        private static readonly string proximaPath = "./res/icon/proxima.png";
        private static readonly Image backgroundImage = Image.FromFile(backgroundPath);
        private static readonly Image ueCoinImage = Image.FromFile(ueCoinPath);
        private static readonly Image sCoinImage = Image.FromFile(sCoinPath);
        private static readonly Image proximaImage = Image.FromFile(proximaPath);
        public static Stream CreateProfilBanner(Image avatar, PlayerAccount player)
        {
            MemoryStream stream = new MemoryStream();
            using (Bitmap background = new Bitmap(backgroundImage, new Size(400, 100)))
            {
                using (Bitmap ueCoin = new Bitmap(ueCoinImage, new Size(35, 35)))
                {
                    using (Bitmap proxima = new Bitmap(proximaImage, new Size(35, 35)))
                    {
                        using (Bitmap sCoin = new Bitmap(sCoinImage, new Size(35, 35)))
                        {
                            using (Graphics g = Graphics.FromImage(background))
                            {
                                int iconHeight = 10;
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                                g.DrawEllipse(new Pen(Brushes.Gold, 3), new Rectangle(9, 9, 82, 82));
                                g.DrawImage(new Bitmap(RoundCorners(avatar, avatar.Width / 2, Color.Transparent), new Size(80, 80)), new Point(10, 10));
                                g.DrawImage(ueCoin, new Point(110, iconHeight));
                                g.DrawImage(proxima, new Point(210, iconHeight));
                                g.DrawImage(sCoin, new Point(310, iconHeight));

                                Font font = new Font(new FontFamily("Arial"), 14, FontStyle.Regular);
                                Brush brush = Brushes.LightGray;
                                g.DrawString(player.ueCoin.ToString(), font, brush, new RectangleF(110, 60, 90, 40));
                                g.DrawString(player.proxima.ToString(), font, brush, new RectangleF(210, 60, 90, 40));
                                g.DrawString(player.sCoin.ToString(), font, brush, new RectangleF(310, 60, 90, 40));
                            }
                        }
                    }
                }
                background.Save(stream, ImageFormat.Png);
            };
            stream.Position = 0;
            return stream;
        }

        private static Image RoundCorners(Image StartImage, int CornerRadius, Color BackgroundColor)
        {
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
            using (Graphics g = Graphics.FromImage(RoundedImage))
            {
                g.Clear(BackgroundColor);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Brush brush = new TextureBrush(StartImage);
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                g.FillPath(brush, gp);
                return RoundedImage;
            }
        }
    }
}
