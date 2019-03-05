using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using ConnectorLib;
using JetBrains.Annotations;

namespace ALTTPR.Multiworld
{
    public class GameStateProcessor
    {
        public bool Bow { get; set; }

        public bool SilverArrows { get; set; }

        public bool BlueBoomerang { get; set; }

        public bool RedBoomerang { get; set; }

        public bool Hookshot { get; set; }

        public byte Bombs { get; set; }

        public bool Mushroom { get; set; }

        public bool Powder { get; set; }

        public bool FireRod { get; set; }

        public bool IceRod { get; set; }

        public bool Bombos { get; set; }

        public bool Ether { get; set; }

        public bool Quake { get; set; }

        public bool Lamp { get; set; }

        public bool Hammer { get; set; }

        public bool BugNet { get; set; }

        public bool Book { get; set; }

        public bool RedCane { get; set; }

        public bool BlueCane { get; set; }

        public bool Boots { get; set; }

        public bool Cape { get; set; }

        public bool Mirror { get; set; }

        public bool Flippers { get; set; }

        public bool Shovel { get; set; }

        public GameState.GloveType Glove { get; set; }

        public bool MoonPearl { get; set; }

        public GameState.SwordType Sword { get; set; }

        public GameState.ShieldType Shield { get; set; }

        public GameState.ArmorType Armor { get; set; }

        public GameState.FluteType Flute { get; set; }

        public GameState.MagicType Magic { get; set; }

        [NotNull] private readonly GameState.BottleContentsType[] _bottles = new GameState.BottleContentsType[4];
        
        public GameState.BottleContentsType Bottle1
        {
            get => _bottles[0];
            set => _bottles[0] = value;
        }

        public GameState.BottleContentsType Bottle2
        {
            get => _bottles[1];
            set => _bottles[1] = value;
        }

        public GameState.BottleContentsType Bottle3
        {
            get => _bottles[2];
            set => _bottles[2] = value;
        }

        public GameState.BottleContentsType Bottle4
        {
            get => _bottles[3];
            set => _bottles[3] = value;
        }

        [NotNull] public GameState.BottleContentsType[] Bottles => _bottles;

        public GameStateProcessor([NotNull] GameStateReaderWriter reader) => ReadState(reader);

        public void ReadState([NotNull] GameStateReaderWriter reader)
        {
            reader.Read();
            //Bow = reader.Bow;
            //SilverArrows = reader.SilverArrows;
            BlueBoomerang = reader.BlueBoomerang;
            RedBoomerang = reader.RedBoomerang;
            Hookshot = reader.Hookshot;
            Mushroom = reader.Mushroom;
            Powder = reader.Powder;
            FireRod = reader.FireRod;
            IceRod = reader.IceRod;
            Bombos = reader.Bombos;
            Ether = reader.Ether;
            Quake = reader.Quake;
            Lamp = reader.Lamp;
            Hammer = reader.Hammer;
            //Shovel = reader.Shovel;
            //Flute = reader.Flute;
            BugNet = reader.BugNet;
            Book = reader.Book;
            Bottle1 = reader.Bottle1;
            //Bottle2 = reader.Bottle2;
            //Bottle3 = reader.Bottle3;
            //Bottle4 = reader.Bottle4;
            RedCane = reader.RedCane;
            BlueCane = reader.BlueCane;
            Cape = reader.Cape;
            Mirror = reader.Mirror;
            //Boots = reader.Boots;
            Glove = reader.Glove;
            //Flippers = reader.Flippers;
            MoonPearl = reader.MoonPearl;
        }

        public async Task<bool> AddBottle(GameState.BottleContentsType contents)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Bottles[i] == GameState.BottleContentsType.NoBottle)
                {
                    Bottles[i] = contents;
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ItemGet(GameState.Item item)
        {
            Read();
            switch (item)
            {
                case GameState.Item.FightersSwordAndShield:
                    if (Sword == GameState.SwordType.NoSword) { Sword = GameState.SwordType.FightersSword; }
                    if (Shield == GameState.ShieldType.NoSword) { Shield = GameState.ShieldType.FightersShield; }
                    break;
                case GameState.Item.MasterSword:
                    if (Sword < GameState.SwordType.MasterSword) { Sword = GameState.SwordType.MasterSword; }
                    break;
                case GameState.Item.TemperedSword:
                    if (Sword < GameState.SwordType.TemperedSword) { Sword = GameState.SwordType.TemperedSword; }
                    break;
                case GameState.Item.GoldenSword:
                    if (Sword < GameState.SwordType.GoldenSword) { Sword = GameState.SwordType.GoldenSword; }
                    break;
                case GameState.Item.FightersShield:
                    if (Shield == GameState.ShieldType.FightersShield) { Shield = GameState.ShieldType.FightersShield; }
                    break;
                case GameState.Item.FireShield:
                    if (Shield == GameState.ShieldType.FightersShield) { Shield = GameState.ShieldType.FightersShield; }
                    break;
                case GameState.Item.MirrorShield:
                    if (Shield == GameState.ShieldType.FightersShield) { Shield = GameState.ShieldType.FightersShield; }
                    break;
                case GameState.Item.FireRod:
                    FireRod = true;
                    break;
                case GameState.Item.IceRod:
                    IceRod = true;
                    break;
                case GameState.Item.Hammer:
                    Hammer = true;
                    break;
                case GameState.Item.HookShot:
                    Hookshot = true;
                    break;
                case GameState.Item.Bow:
                    Bow = true;
                    break;
                case GameState.Item.BlueBoomerang:
                    BlueBoomerang = true;
                    break;
                case GameState.Item.Powder:
                    Powder = true;
                    break;
                case GameState.Item.Bee:
                    break;
                case GameState.Item.Bombos:
                    Bombos = true;
                    break;
                case GameState.Item.Ether:
                    Ether = true;
                    break;
                case GameState.Item.Quake:
                    Quake = true;
                    break;
                case GameState.Item.Lamp:
                    Lamp = true;
                    break;
                case GameState.Item.Shovel:
                    Shovel = true;
                    break;
                case GameState.Item.FluteInactive:
                    if (Flute < GameState.FluteType.Inactive) { Flute = GameState.FluteType.Inactive; }
                    break;
                case GameState.Item.RedCane:
                    RedCane = true;
                    break;
                case GameState.Item.Bottle:
                    return await AddBottle(GameState.BottleContentsType.Empty);
                case GameState.Item.HeartPiece:
                    break;
                case GameState.Item.BlueCane:
                    BlueCane = true;
                    break;
                case GameState.Item.Cape:
                    Cape = true;
                    break;
                case GameState.Item.Mirror:
                    Mirror = true;
                    break;
                case GameState.Item.PowerGlove:
                    if (Glove < GameState.GloveType.PowerGlove) { Glove = GameState.GloveType.PowerGlove; }
                    break;
                case GameState.Item.TitansMitt:
                    if (Glove < GameState.GloveType.TitansMitt) { Glove = GameState.GloveType.TitansMitt; }
                    break;
                case GameState.Item.Book:
                    Book = true;
                    break;
                case GameState.Item.Flippers:
                    Flippers = true;
                    break;
                case GameState.Item.MoonPearl:
                    MoonPearl = true;
                    break;
                case GameState.Item.Crystal:
                    break;
                case GameState.Item.BugNet:
                    BugNet = true;
                    break;
                case GameState.Item.BlueMail:
                    if (Armor < GameState.ArmorType.BlueMail) { Armor = GameState.ArmorType.BlueMail; }
                    break;
                case GameState.Item.RedMail:
                    if (Armor < GameState.ArmorType.RedMail) { Armor = GameState.ArmorType.RedMail; }
                    break;
                case GameState.Item.SmallKey:
                    break;
                case GameState.Item.Compass:
                    break;
                case GameState.Item.HeartPieceCompletionHeart:
                    break;
                case GameState.Item.Bomb:
                    break;
                case GameState.Item.ThreeBombs:
                    break;
                case GameState.Item.Mushroom:
                    Mushroom = true;
                    break;
                case GameState.Item.RedBoomerang:
                    RedBoomerang = true;
                    break;
                case GameState.Item.RedPotionWithBottle:
                    return await AddBottle(GameState.BottleContentsType.RedPotion);
                case GameState.Item.GreenPotionWithBottle:
                    return await AddBottle(GameState.BottleContentsType.GreenPotion);
                case GameState.Item.BluePotionWithBottle:
                    return await AddBottle(GameState.BottleContentsType.BluePotion);
                case GameState.Item.RedPotionWithoutBottle:
                    break;
                case GameState.Item.GreenPotionWithoutBottle:
                    break;
                case GameState.Item.BluePotionWithoutBottle:
                    break;
                case GameState.Item.TenBombs:
                    break;
                case GameState.Item.BigKey:
                    break;
                case GameState.Item.Map:
                    break;
                case GameState.Item.OneRupee:
                    break;
                case GameState.Item.FiveRupees:
                    break;
                case GameState.Item.TwentyRupees:
                    break;
                case GameState.Item.Pendant1:
                    break;
                case GameState.Item.Pendant2:
                    break;
                case GameState.Item.Pendant3:
                    break;
                case GameState.Item.BowAndArrows:
                    Bow = true;
                    break;
                case GameState.Item.BowAndSilverArrows:
                    Bow = true;
                    SilverArrows = true;
                    break;
                case GameState.Item.BeeWithBottle:
                    return await AddBottle(GameState.BottleContentsType.Bee);
                case GameState.Item.Fairy:
                    return await AddBottle(GameState.BottleContentsType.Fairy);
                case GameState.Item.BossHeart:
                    break;
                case GameState.Item.SanctuaryHeart:
                    break;
                case GameState.Item.OneHundredRupees:
                    break;
                case GameState.Item.FiftyRupees:
                    break;
                case GameState.Item.Heart:
                    break;
                case GameState.Item.Arrow:
                    break;
                case GameState.Item.TenArrows:
                    break;
                case GameState.Item.Magic:
                    break;
                case GameState.Item.ThreeHundredRupees:
                    break;
                case GameState.Item.GreenTwentyRupees:
                    break;
                case GameState.Item.GoldBee:
                    break;
                case GameState.Item.FightersSword:
                    if (Sword == GameState.SwordType.NoSword) { Sword = GameState.SwordType.FightersSword; }
                    break;
                case GameState.Item.FluteActive:
                    Flute = GameState.FluteType.Active;
                    break;
                case GameState.Item.Boots:
                    Boots = true;
                    break;
                case GameState.Item.MaxBombs:
                    break;
                case GameState.Item.MaxArrows:
                    break;
                case GameState.Item.HalfMagic:
                    if (Magic < GameState.MagicType.HalfMagic) { Magic = GameState.MagicType.HalfMagic; }
                    break;
                case GameState.Item.QuarterMagic:
                    Magic = GameState.MagicType.QuarterMagic;
                    break;
                case GameState.Item.MasterSwordSafe:
                    if (Sword < GameState.SwordType.MasterSword) { Sword = GameState.SwordType.MasterSword; }
                    break;
                case GameState.Item.PlusFiveBombs:
                    break;
                case GameState.Item.PlusTenBombs:
                    break;
                case GameState.Item.PlusFiveArrows:
                    break;
                case GameState.Item.PlusTenArrows:
                    break;
                case GameState.Item.ProgrammableItem1:
                    break;
                case GameState.Item.ProgrammableItem2:
                    break;
                case GameState.Item.ProgrammableItem3:
                    break;
                case GameState.Item.UpgradeOnlySilverArrows:
                    SilverArrows = true;
                    break;
                case GameState.Item.Rupoor:
                    break;
                case GameState.Item.NullItem:
                    break;
                case GameState.Item.RedClock:
                    break;
                case GameState.Item.BlueClock:
                    break;
                case GameState.Item.GreenClock:
                    break;
                case GameState.Item.ProgressiveSword:
                    if (Sword < GameState.SwordType.GoldenSword) { Sword++; }
                    break;
                case GameState.Item.ProgressiveShield:
                    if (Shield < GameState.ShieldType.MirrorShield) { Shield++; }
                    break;
                case GameState.Item.ProgressiveArmor:
                    if (Armor < GameState.ArmorType.RedMail) { Armor++; }
                    break;
                case GameState.Item.ProgressiveLiftingGlove:
                    if (Glove < GameState.GloveType.TitansMitt) { Glove++; }
                    break;
                case GameState.Item.RNGPoolItemSingle:
                    break;
                case GameState.Item.RNGPoolItemMulti:
                    break;
                case GameState.Item.GoalItemSingle:
                    break;
                case GameState.Item.GoalItemMulti:
                    break;
                case GameState.Item.MapOfLightWorld:
                    break;
                case GameState.Item.MapOfDarkWorld:
                    break;
                case GameState.Item.MapOfGanonsTower:
                    break;
                case GameState.Item.MapOfTurtleRock:
                    break;
                case GameState.Item.MapOfThievesTown:
                    break;
                case GameState.Item.MapOfTowerOfHera:
                    break;
                case GameState.Item.MapOfIcePalace:
                    break;
                case GameState.Item.MapOfSkullWoods:
                    break;
                case GameState.Item.MapOfMiseryMire:
                    break;
                case GameState.Item.MapOfDarkPalace:
                    break;
                case GameState.Item.MapOfSwampPalace:
                    break;
                case GameState.Item.MapOfAgahnimsTower:
                    break;
                case GameState.Item.MapOfDesertPalace:
                    break;
                case GameState.Item.MapOfEasternPalace:
                    break;
                case GameState.Item.MapOfHyruleCastle:
                    break;
                case GameState.Item.MapOfSewers:
                    break;
                case GameState.Item.CompassOfLightWorld:
                    break;
                case GameState.Item.CompassOfDarkWorld:
                    break;
                case GameState.Item.CompassOfGanonsTower:
                    break;
                case GameState.Item.CompassOfTurtleRock:
                    break;
                case GameState.Item.CompassOfThievesTown:
                    break;
                case GameState.Item.CompassOfTowerOfHera:
                    break;
                case GameState.Item.CompassOfIcePalace:
                    break;
                case GameState.Item.CompassOfSkullWoods:
                    break;
                case GameState.Item.CompassOfMiseryMire:
                    break;
                case GameState.Item.CompassOfDarkPalace:
                    break;
                case GameState.Item.CompassOfSwampPalace:
                    break;
                case GameState.Item.CompassOfAgahnimsTower:
                    break;
                case GameState.Item.CompassOfDesertPalace:
                    break;
                case GameState.Item.CompassOfEasternPalace:
                    break;
                case GameState.Item.CompassOfHyruleCastle:
                    break;
                case GameState.Item.CompassOfSewers:
                    break;
                case GameState.Item.SkullKey:
                    break;
                case GameState.Item.Reserved2:
                    break;
                case GameState.Item.BigKeyOfGanonsTower:
                    break;
                case GameState.Item.BigKeyOfTurtleRock:
                    break;
                case GameState.Item.BigKeyOfThievesTown:
                    break;
                case GameState.Item.BigKeyOfTowerOfHera:
                    break;
                case GameState.Item.BigKeyOfIcePalace:
                    break;
                case GameState.Item.BigKeyOfSkullWoods:
                    break;
                case GameState.Item.BigKeyOfMiseryMire:
                    break;
                case GameState.Item.BigKeyOfDarkPalace:
                    break;
                case GameState.Item.BigKeyOfSwampPalace:
                    break;
                case GameState.Item.BigKeyOfAgahnimsTower:
                    break;
                case GameState.Item.BigKeyOfDesertPalace:
                    break;
                case GameState.Item.BigKeyOfEasternPalace:
                    break;
                case GameState.Item.BigKeyOfHyruleCastle:
                    break;
                case GameState.Item.BigKeyOfSewers:
                    break;
                case GameState.Item.SmallKeyOfSewers:
                    break;
                case GameState.Item.SmallKeyOfHyruleCastle:
                    break;
                case GameState.Item.SmallKeyOfEasternPalace:
                    break;
                case GameState.Item.SmallKeyOfDesertPalace:
                    break;
                case GameState.Item.SmallKeyOfAgahnimsTower:
                    break;
                case GameState.Item.SmallKeyOfSwampPalace:
                    break;
                case GameState.Item.SmallKeyOfDarkPalace:
                    break;
                case GameState.Item.SmallKeyOfMiseryMire:
                    break;
                case GameState.Item.SmallKeyOfSkullWoods:
                    break;
                case GameState.Item.SmallKeyOfIcePalace:
                    break;
                case GameState.Item.SmallKeyOfTowerOfHera:
                    break;
                case GameState.Item.SmallKeyOfThievesTown:
                    break;
                case GameState.Item.SmallKeyOfTurtleRock:
                    break;
                case GameState.Item.SmallKeyOfGanonsTower:
                    break;
                case GameState.Item.Reserved:
                    break;
                case GameState.Item.GenericSmallKey:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(item), item, null);
            }
            return true;
        }



        public bool Read()
        {
            return false;
        }
    }
}
