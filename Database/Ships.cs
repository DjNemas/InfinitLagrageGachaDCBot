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

        public string name { get; private set; }
        public ShipType type { get; private set; }
        public Image shipImage { get; private set; } 


        private static readonly string shipFolder = "./res/ships/";
        private static readonly string frigateFolder = "frigate/";
        private static readonly string destoryerFolder = "destoryer/";
        private static readonly string cruiserFolder = "cruiser/";
        private static readonly string battlecruiserFolder = "battlecruiser/";
        private static readonly string carrierFolder = "carrier/";
        private static readonly string fighterFolder = "fighter/";
        private static readonly string corvetsFolder = "corvets/";

        public Ships(string _name, ShipType _type)
        {
            this.name = _name;
            this.type = _type;
        }

        public static void CreatShipList()
        {
            // Firgats
            Ships ship = new Ships("Carilion", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "carilion.png");
            shipList.Add(ship);
            ship = new Ships("FG300", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "fg300.png");
            shipList.Add(ship);
            ship = new Ships("Mare Tranquillitatis", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "mare_tranquillitatis.png");
            shipList.Add(ship);
            ship = new Ships("Mare Nubium", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "mare_nubium.png");
            shipList.Add(ship);
            ship = new Ships("Mare Serenitatis", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "mare_serenitatis.png");
            shipList.Add(ship);
            ship = new Ships("Noma M470", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "noma_m470.png");
            shipList.Add(ship);
            ship = new Ships("Reliat", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "reliat.png");
            shipList.Add(ship);
            ship = new Ships("Ruby", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "ruby.png");
            shipList.Add(ship);
            ship = new Ships("Xenostringer", ShipType.frigate);
            ship.shipImage = Image.FromFile(shipFolder + frigateFolder + "xenostringer.png");
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
}
