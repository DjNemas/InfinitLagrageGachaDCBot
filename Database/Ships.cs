using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitLagrageGachaDCBot.Database
{
    class Ships
    {
        public static readonly List<Ships> shipList = new List<Ships>();

        public ShipName ShipName { get; private set; }
        public ShipType ShipType { get; private set; }
        public Image ShipImage { get; private set; }


        private static readonly string shipFolder = "./res/ships/";
        private static readonly string frigateFolder = "frigate/";
        private static readonly string destoryerFolder = "destoryer/";
        private static readonly string cruiserFolder = "cruiser/";
        private static readonly string battlecruiserFolder = "battlecruiser/";
        private static readonly string carrierFolder = "carrier/";
        private static readonly string fighterFolder = "fighter/";
        private static readonly string corvetsFolder = "corvets/";

        public Ships(ShipName _name, ShipType _type)
        {
            this.ShipName = _name;
            this.ShipType = _type;
        }

        public static void CreatShipList()
        {
            // Firgats
            Ships ship = new Ships(ShipName.Carilion, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "carilion.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.FG300, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "fg300.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.MareTranquillitatis, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "mare_tranquillitatis.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.MareNubium, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "mare_nubium.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.MareSerenitatis, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "mare_serenitatis.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.NomaM470, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "noma_m470.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.Reliat, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "reliat.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.Ruby, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "ruby.png");
            shipList.Add(ship);
            ship = new Ships(ShipName.Xenostringer, ShipType.frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "xenostringer.png");
            shipList.Add(ship);
        }
    }

    public enum ShipType
    {
        frigate,
        destoryer,
        cruiser,
        battlecruiser,
        carrier,
        fighter,
        corvets
    }

    public enum ShipName
    {
        Carilion,
        FG300,
        MareTranquillitatis,
        MareNubium,
        MareSerenitatis,
        NomaM470,
        Reliat,
        Ruby,
        Xenostringer

    }
}
