using System.ComponentModel;

namespace ALTTPR.Multiworld
{
    public class GameState
    {
        public enum Item : byte
        {
            FightersSwordAndShield = 0x00,
            MasterSword = 0x01,
            TemperedSword = 0x02,
            GoldenSword = 0x03,
            FightersShield = 0x04,
            FireShield = 0x05,
            MirrorShield = 0x06,
            FireRod = 0x07,
            IceRod = 0x08,
            Hammer = 0x09,
            HookShot = 0x0A,
            Bow = 0x0B,
            BlueBoomerang = 0x0C,
            Powder = 0x0D,
            Bee = 0x0E,
            Bombos = 0x0F,
            Ether = 0x10,
            Quake = 0x11,
            Lamp = 0x12,
            Shovel = 0x13,
            FluteInactive = 0x14,
            RedCane = 0x15,
            Bottle = 0x16,
            HeartPiece = 0x17,
            BlueCane = 0x18,
            Cape = 0x19,
            Mirror = 0x1A,
            PowerGlove = 0x1B,
            TitansMitt = 0x1C,
            Book = 0x1D,
            Flippers = 0x1E,
            MoonPearl = 0x1F,
            Crystal = 0x20,
            BugNet = 0x21,
            BlueMail = 0x22,
            RedMail = 0x23,
            SmallKey = 0x24,
            Compass = 0x25,
            HeartPieceCompletionHeart = 0x26,
            Bomb = 0x27,
            ThreeBombs = 0x28,
            Mushroom = 0x29,
            RedBoomerang = 0x2A,
            RedPotionWithBottle = 0x2B,
            GreenPotionWithBottle = 0x2C,
            BluePotionWithBottle = 0x2D,
            RedPotionWithoutBottle = 0x2E,
            GreenPotionWithoutBottle = 0x2F,
            BluePotionWithoutBottle = 0x30,
            TenBombs = 0x31,
            BigKey = 0x32,
            Map = 0x33,
            OneRupee = 0x34,
            FiveRupees = 0x35,
            TwentyRupees = 0x36,
            Pendant1 = 0x37,
            Pendant2 = 0x38,
            Pendant3 = 0x39,
            BowAndArrows = 0x3A,
            BowAndSilverArrows = 0x3B,
            BeeWithBottle = 0x3C,
            Fairy = 0x3D,
            BossHeart = 0x3E,
            SanctuaryHeart = 0x3F,
            OneHundredRupees = 0x40,
            FiftyRupees = 0x41,
            Heart = 0x42,
            Arrow = 0x43,
            TenArrows = 0x44,
            Magic = 0x45,
            ThreeHundredRupees = 0x46,
            GreenTwentyRupees = 0x47,
            GoldBee = 0x48,
            FightersSword = 0x49,
            FluteActive = 0x4A,
            Boots = 0x4B,
            MaxBombs = 0x4C,
            MaxArrows = 0x4D,
            HalfMagic = 0x4E,
            QuarterMagic = 0x4F,
            MasterSwordSafe = 0x50,
            PlusFiveBombs = 0x51,
            PlusTenBombs = 0x52,
            PlusFiveArrows = 0x53,
            PlusTenArrows = 0x54,
            ProgrammableItem1 = 0x55,
            ProgrammableItem2 = 0x56,
            ProgrammableItem3 = 0x57,
            UpgradeOnlySilverArrows = 0x58,
            Rupoor = 0x59,
            NullItem = 0x5A,
            RedClock = 0x5B,
            BlueClock = 0x5C,
            GreenClock = 0x5D,
            ProgressiveSword = 0x5E,
            ProgressiveShield = 0x5F,
            ProgressiveArmor = 0x60,
            ProgressiveLiftingGlove = 0x61,
            RNGPoolItemSingle = 0x62,
            RNGPoolItemMulti = 0x63,
            GoalItemSingle = 0x6A,
            GoalItemMulti = 0x6B,
            MapOfLightWorld = 0x70,
            MapOfDarkWorld = 0x71,
            MapOfGanonsTower = 0x72,
            MapOfTurtleRock = 0x73,
            MapOfThievesTown = 0x74,
            MapOfTowerOfHera = 0x75,
            MapOfIcePalace = 0x76,
            MapOfSkullWoods = 0x77,
            MapOfMiseryMire = 0x78,
            MapOfDarkPalace = 0x79,
            MapOfSwampPalace = 0x7A,
            MapOfAgahnimsTower = 0x7B,
            MapOfDesertPalace = 0x7C,
            MapOfEasternPalace = 0x7D,
            MapOfHyruleCastle = 0x7E,
            MapOfSewers = 0x7F,
            CompassOfLightWorld = 0x80,
            CompassOfDarkWorld = 0x81,
            CompassOfGanonsTower = 0x82,
            CompassOfTurtleRock = 0x83,
            CompassOfThievesTown = 0x84,
            CompassOfTowerOfHera = 0x85,
            CompassOfIcePalace = 0x86,
            CompassOfSkullWoods = 0x87,
            CompassOfMiseryMire = 0x88,
            CompassOfDarkPalace = 0x89,
            CompassOfSwampPalace = 0x8A,
            CompassOfAgahnimsTower = 0x8B,
            CompassOfDesertPalace = 0x8C,
            CompassOfEasternPalace = 0x8D,
            CompassOfHyruleCastle = 0x8E,
            CompassOfSewers = 0x8F,
            SkullKey = 0x90,
            Reserved2 = 0x91,
            BigKeyOfGanonsTower = 0x92,
            BigKeyOfTurtleRock = 0x93,
            BigKeyOfThievesTown = 0x94,
            BigKeyOfTowerOfHera = 0x95,
            BigKeyOfIcePalace = 0x96,
            BigKeyOfSkullWoods = 0x97,
            BigKeyOfMiseryMire = 0x98,
            BigKeyOfDarkPalace = 0x99,
            BigKeyOfSwampPalace = 0x9A,
            BigKeyOfAgahnimsTower = 0x9B,
            BigKeyOfDesertPalace = 0x9C,
            BigKeyOfEasternPalace = 0x9D,
            BigKeyOfHyruleCastle = 0x9E,
            BigKeyOfSewers = 0x9F,
            SmallKeyOfSewers = 0xA0,
            SmallKeyOfHyruleCastle = 0xA1,
            SmallKeyOfEasternPalace = 0xA2,
            SmallKeyOfDesertPalace = 0xA3,
            SmallKeyOfAgahnimsTower = 0xA4,
            SmallKeyOfSwampPalace = 0xA5,
            SmallKeyOfDarkPalace = 0xA6,
            SmallKeyOfMiseryMire = 0xA7,
            SmallKeyOfSkullWoods = 0xA8,
            SmallKeyOfIcePalace = 0xA9,
            SmallKeyOfTowerOfHera = 0xAA,
            SmallKeyOfThievesTown = 0xAB,
            SmallKeyOfTurtleRock = 0xAC,
            SmallKeyOfGanonsTower = 0xAD,
            Reserved = 0xAE,
            GenericSmallKey = 0xAF
        }

        public enum BowType : byte
        {
            [Description("No Bow")]
            NoBow = 0,
            [Description("Wooden Bow")]
            WoodenBow = 1,
            [Description("Silver Bow")]
            SilverBow = 2
        }

        public enum SwordType : byte
        {
            [Description("No Sword")]
            NoSword = 0,
            [Description("Fighter's Sword")]
            FightersSword = 1,
            [Description("Master Sword")]
            MasterSword = 2,
            [Description("Tempered Sword")]
            TemperedSword = 3,
            [Description("Golden Sword")]
            GoldenSword = 4
        }

        public enum ShieldType : byte
        {
            [Description("No Shield")]
            NoSword = 0,
            [Description("Fighter's Shield")]
            FightersShield = 1,
            [Description("Fire Shield")]
            FireShield = 2,
            [Description("Mirror Shield")]
            MirrorShield = 3
        }

        public enum ArmorType : byte
        {
            [Description("Green Tunic")]
            GreenTunic = 0,
            [Description("Blue Mail")]
            BlueMail = 1,
            [Description("Red Mail")]
            RedMail = 2
        }

        public enum GloveType : byte
        {
            [Description("No Glove")]
            NoGlove = 0,
            [Description("Power Glove")]
            PowerGlove = 1,
            [Description("Titan's Mitt")]
            TitansMitt = 2
        }

        public enum BoomerangType : byte
        {
            [Description("No Boomerang")]
            NoBoomerang = 0,
            [Description("Blue Boomerang")]
            BlueBoomerang = 1,
            [Description("Red Boomerang")]
            RedBoomerang = 2
        }

        public enum FluteType : byte
        {
            [Description("No Flute")]
            NoFlute = 0,
            Shovel = 1,
            [Description("Inactive Flute")]
            Inactive = 2,
            [Description("Inactive Flute")]
            Active = 3
        }

        public enum MagicType : byte
        {
            [Description("Normal Magic")]
            NormalMagic = 0,
            [Description("Half Magic")]
            HalfMagic = 1,
            [Description("Quarter Magic")]
            QuarterMagic = 2
        }

        public enum BottleContentsType : byte
        {
            [Description("No Bottle")]
            NoBottle = 0,
            Mushroom = 1,
            [Description("Empty Bottle")]
            Empty = 2,
            [Description("Red Potion")]
            RedPotion = 3,
            [Description("Green Potion")]
            GreenPotion = 4,
            [Description("Blue Potion")]
            BluePotion = 5,
            Fairy = 6,
            Bee = 7,
            [Description("Golden Bee")]
            GoldenBee = 8
        }
    }
}
