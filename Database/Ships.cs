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
        public static readonly List<Ships> shipListFrigates = new List<Ships>();
        public static readonly List<Ships> shipListDestroyer = new List<Ships>();
        public static readonly List<Ships> shipListCruiser = new List<Ships>();
        public static readonly List<Ships> shipListBattlecruiser = new List<Ships>();
        public static readonly List<Ships> shipListCarrier = new List<Ships>();
        public static readonly List<Ships> shipListFighter = new List<Ships>();
        public static readonly List<Ships> shipListCorvettes = new List<Ships>();
        public static readonly List<Ships> shipListTechpoints = new List<Ships>();

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
        private static readonly string corvetsFolder = "corvettes/";
        private static readonly string techpointsFolder = "techpoints/";

        public Ships(ShipName _name, ShipType _type)
        {
            this.ShipName = _name;
            this.ShipType = _type;
        }

        public static void CreatShipList()
        {
            // Firgats
            Ships ship = new Ships(ShipName.Carilion, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "carilion.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.FG300, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "fg300.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.MareTranquillitatis, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "mare_tranquillitatis.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.MareNubium, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "mare_nubium.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.MareSerenitatis, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "mare_serenitatis.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.NomaM470, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "noma_m470.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.Reliat, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "reliat.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.Ruby, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "ruby.png");
            shipListFrigates.Add(ship);
            ship = new Ships(ShipName.Xenostringer, ShipType.Frigate);
            ship.ShipImage = Image.FromFile(shipFolder + frigateFolder + "xenostringer.png");
            shipListFrigates.Add(ship);
            // Destoyer
            ship = new Ships(ShipName.Guardian, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "guardian.png");
            shipListDestroyer.Add(ship);
            ship = new Ships(ShipName.Tundra, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "tundra.png");
            shipListDestroyer.Add(ship);
            ship = new Ships(ShipName.Taurus, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "taurus.png");
            shipListDestroyer.Add(ship);
            ship = new Ships(ShipName.Ceres, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "ceres.png");
            shipListDestroyer.Add(ship);
            ship = new Ships(ShipName.AC721, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "ac721.png");
            shipListDestroyer.Add(ship);
            ship = new Ships(ShipName.ErisI, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "eris_i.png");
            shipListDestroyer.Add(ship);
            ship = new Ships(ShipName.WingedHussar, ShipType.Destoryer);
            ship.ShipImage = Image.FromFile(shipFolder + destoryerFolder + "winged_hussar.png");
            shipListDestroyer.Add(ship);
            // Cruiser
            ship = new Ships(ShipName.Chimera, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "chimera.png");
            shipListCruiser.Add(ship);
            ship = new Ships(ShipName.LightCone, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "light_cone.png");
            shipListCruiser.Add(ship);
            ship = new Ships(ShipName.Callisto, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "callisto.png");
            shipListCruiser.Add(ship);
            ship = new Ships(ShipName.Predator, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "predator.png");
            shipListCruiser.Add(ship);
            ship = new Ships(ShipName.Io, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "io.png");
            shipListCruiser.Add(ship);
            ship = new Ships(ShipName.Cas066, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "cas066.png");
            shipListCruiser.Add(ship);
            ship = new Ships(ShipName.KCCPV20, ShipType.Cruiser);
            ship.ShipImage = Image.FromFile(shipFolder + cruiserFolder + "kccpv20.png");
            shipListCruiser.Add(ship);
            // BattleCruiser
            ship = new Ships(ShipName.SpearOfUranus, ShipType.Battlecruiser);
            ship.ShipImage = Image.FromFile(shipFolder + battlecruiserFolder + "spear_of_uranus.png");
            shipListBattlecruiser.Add(ship);
            ship = new Ships(ShipName.ConstantineTheGreat, ShipType.Battlecruiser);
            ship.ShipImage = Image.FromFile(shipFolder + battlecruiserFolder + "constantine_the_great.png");
            shipListBattlecruiser.Add(ship);
            ship = new Ships(ShipName.EternalStorm, ShipType.Battlecruiser);
            ship.ShipImage = Image.FromFile(shipFolder + battlecruiserFolder + "eternal_storm.png");
            shipListBattlecruiser.Add(ship);
            ship = new Ships(ShipName.ST59, ShipType.Battlecruiser);
            ship.ShipImage = Image.FromFile(shipFolder + battlecruiserFolder + "st59.png");
            shipListBattlecruiser.Add(ship);
            // Carrier
            ship = new Ships(ShipName.SolarWhale, ShipType.Carrier);
            ship.ShipImage = Image.FromFile(shipFolder + carrierFolder + "solar_whale.png");
            shipListCarrier.Add(ship);
            ship = new Ships(ShipName.CV3000, ShipType.Carrier);
            ship.ShipImage = Image.FromFile(shipFolder + carrierFolder + "cv3000.png");
            shipListCarrier.Add(ship);
            // Fighter
            ship = new Ships(ShipName.JanbiyaAer410, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "janbiya_aer410.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.Stringray, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "stringray.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.SporeA404, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "spore_a404.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.B192Newland, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "b192_newland.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.VitasB010, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "vitas-b010.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.VitasA021, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "vitas_a021.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.BalancerAndersonSC020, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "balancer_anderson_sc020.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.StrixA100, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "strix_a100.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.Bullfrog, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "bullfrog.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.Sandrake, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "sandrake.png");
            shipListFighter.Add(ship);
            ship = new Ships(ShipName.SC002, ShipType.Fighter);
            ship.ShipImage = Image.FromFile(shipFolder + fighterFolder + "sc002.png");
            shipListFighter.Add(ship);
            // Corvettes
            ship = new Ships(ShipName.CVM011, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "cv-m011.png");
            shipListCorvettes.Add(ship);
            ship = new Ships(ShipName.VoidElfin, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "void_elfin.png");
            shipListCorvettes.Add(ship);
            ship = new Ships(ShipName.NebularChaser, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "nebula_chaser.png");
            shipListCorvettes.Add(ship);
            ship = new Ships(ShipName.CellularDefender, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "cellular_defender.png");
            shipListCorvettes.Add(ship);
            ship = new Ships(ShipName.RedBeast713, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "redbeast_7-13.png");
            shipListCorvettes.Add(ship);
            ship = new Ships(ShipName.CVII003, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "cv-ii003.png");
            shipListCorvettes.Add(ship);
            ship = new Ships(ShipName.SilentAssasin, ShipType.Corvets);
            ship.ShipImage = Image.FromFile(shipFolder + corvetsFolder + "silent_assassin.png");
            shipListCorvettes.Add(ship);
            // TechPoints
            ship = new Ships(ShipName.TP_Frigate, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "frigate.png");
            shipListTechpoints.Add(ship);
            ship = new Ships(ShipName.TP_Destoryer, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "destroyer.png");
            shipListTechpoints.Add(ship);
            ship = new Ships(ShipName.TP_Cruiser, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "cruiser.png");
            shipListTechpoints.Add(ship);
            ship = new Ships(ShipName.TP_BattleCruiser, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "battlecruiser.png");
            shipListTechpoints.Add(ship);
            ship = new Ships(ShipName.TP_Carrier, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "carrier.png");
            shipListTechpoints.Add(ship);
            ship = new Ships(ShipName.TP_Fighter, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "fighter.png");
            shipListTechpoints.Add(ship);
            ship = new Ships(ShipName.TP_Corvettes, ShipType.Techpoints);
            ship.ShipImage = Image.FromFile(shipFolder + techpointsFolder + "corvette.png");
            shipListTechpoints.Add(ship);
        }
    }

    public enum ShipType
    {
        Frigate,
        Destoryer,
        Cruiser,
        Battlecruiser,
        Carrier,
        Fighter,
        Corvets,
        Techpoints
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
        Xenostringer,
        Guardian,
        Tundra,
        Taurus,
        Ceres,
        AC721,
        ErisI,
        WingedHussar,
        Chimera,
        LightCone,
        Callisto,
        Predator,
        Io,
        Cas066,
        KCCPV20,
        SpearOfUranus,
        ConstantineTheGreat,
        EternalStorm,
        ST59,
        SolarWhale,
        CV3000,
        JanbiyaAer410,
        Stringray,
        SporeA404,
        B192Newland,
        VitasB010,
        VitasA021,
        BalancerAndersonSC020,
        StrixA100,
        Bullfrog,
        Sandrake,
        SC002,
        CVM011,
        VoidElfin,
        NebularChaser,
        CellularDefender,
        RedBeast713,
        CVII003,
        SilentAssasin,
        TP_Frigate,
        TP_Destoryer,
        TP_Cruiser,
        TP_BattleCruiser,
        TP_Carrier,
        TP_Fighter,
        TP_Corvettes
    }
}
