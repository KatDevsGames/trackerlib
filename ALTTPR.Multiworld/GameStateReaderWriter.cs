using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ConnectorLib;
using JetBrains.Annotations;

namespace ALTTPR.Multiworld
{
    public class GameStateReaderWriter
    {
        [NotNull] private readonly ISNESConnector _connector;

        [NotNull] private readonly byte[] _buffer = new byte[0x8c];

        public bool SilverArrows
        {
            get => ((_buffer[(int)Items.RandomizerBow] & 0x80) == 0x80);
            set
            {
                if (value) { _buffer[(int)Items.RandomizerBow] |= 0x80; }
                else
                {
                    _buffer[(int)Items.RandomizerBow] &= 0x7f;
                    if (_buffer[(int)Items.Bow] == (byte)GameState.BowType.SilverBow) { _buffer[(int)Items.Bow] = (byte)GameState.BowType.WoodenBow; }
                }
            }
        }

        public bool Bow
        {
            get => ((_buffer[(int)Items.RandomizerBow] & 0x40) == 0x40);
            set
            {
                if (value)
                {
                    _buffer[(int)Items.RandomizerBow] |= 0x40;
                    if (_buffer[(int)Items.Bow] == (byte)GameState.BowType.NoBow) { _buffer[(int)Items.Bow] = (byte)(SilverArrows ? GameState.BowType.SilverBow : GameState.BowType.WoodenBow); }
                }
                else
                {
                    _buffer[(int)Items.RandomizerBow] &= 0xbf;
                    _buffer[(int)Items.Bow] = (byte)GameState.BowType.NoBow;
                }
            }
        }

        public bool BlueBoomerang
        {
            get => (_buffer[(int)Items.RandomizerBoomerang] & 0x80) == 0x80;
            set
            {
                _buffer[(int)Items.RandomizerBoomerang] = (byte)(value
                    ? _buffer[(int)Items.RandomizerBoomerang] | 0x80
                    : _buffer[(int)Items.RandomizerBoomerang] & 0x7f);
                if (value && (_buffer[(int)Items.Boomerang] == 0)) { _buffer[(int)Items.Boomerang] = (byte)GameState.BoomerangType.BlueBoomerang; }
                else if ((!value) && _buffer[(int)Items.Boomerang] == (byte)GameState.BoomerangType.BlueBoomerang)
                {
                    _buffer[(int)Items.Boomerang] = RedBoomerang
                        ? (byte)GameState.BoomerangType.RedBoomerang
                        : (byte)GameState.BoomerangType.NoBoomerang;
                }
            }
        }

        public bool RedBoomerang
        {
            get => (_buffer[(int)Items.RandomizerBoomerang] & 0x40) == 0x40;
            set
            {
                _buffer[(int)Items.RandomizerBoomerang] = (byte)(value
                    ? _buffer[(int)Items.RandomizerBoomerang] | 0x40
                    : _buffer[(int)Items.RandomizerBoomerang] & 0xbf);
                if (value && (_buffer[(int)Items.Boomerang] == 0)) { _buffer[(int)Items.Boomerang] = (byte)GameState.BoomerangType.RedBoomerang; }
                else if ((!value) && _buffer[(int)Items.Boomerang] == (byte)GameState.BoomerangType.RedBoomerang)
                {
                    _buffer[(int)Items.Boomerang] = BlueBoomerang
                        ? (byte)GameState.BoomerangType.BlueBoomerang
                        : (byte)GameState.BoomerangType.NoBoomerang;
                }
            }
        }

        public bool Shovel
        {
            get => (_buffer[(int)Items.RandomizerShovel] & 0x04) == 0x04;
            set
            {
                _buffer[(int)Items.RandomizerShovel] = (byte)(value
                    ? _buffer[(int)Items.RandomizerShovel] | 0x04
                    : _buffer[(int)Items.RandomizerShovel] & 0xfb);
                if (value && (_buffer[(int)Items.Flute] == (byte)GameState.FluteType.NoFlute)) { _buffer[(int)Items.Flute] = (byte)GameState.FluteType.Shovel; }
                else if ((!value) && _buffer[(int)Items.Flute] == (byte)GameState.FluteType.Shovel)
                {
                    _buffer[(int)Items.Flute] = Flute
                        ? (byte)(FluteActive ? GameState.FluteType.Active : GameState.FluteType.Inactive)
                        : (byte)GameState.FluteType.NoFlute;
                }
            }
        }

        public bool Flute
        {
            get => (_buffer[(int)Items.RandomizerFlute] & 0x03) != 0x00;
            set
            {
                _buffer[(int)Items.RandomizerFlute] = (byte)(value
                    ? _buffer[(int)Items.RandomizerFlute] | (FluteActive ? 0x03 : 0x02)
                    : _buffer[(int)Items.RandomizerFlute] & 0xfc);
                if (value && (_buffer[(int)Items.Flute] == (byte)GameState.FluteType.NoFlute)) { _buffer[(int)Items.Flute] = (byte)(FluteActive ? GameState.FluteType.Active : GameState.FluteType.Inactive); }
                else if ((!value) && _buffer[(int)Items.Flute] > (byte)GameState.FluteType.Shovel)
                {
                    _buffer[(int)Items.Flute] = Shovel
                        ? (byte)GameState.FluteType.Shovel
                        : (byte)GameState.FluteType.NoFlute;
                }
            }
        }

        public bool FluteActive
        {
            get => (_buffer[(int)Items.RandomizerFlute] & 0x01) == 0x01;
            set
            {
                _buffer[(int)Items.RandomizerFlute] = (byte)(value
                    ? ((_buffer[(int)Items.RandomizerFlute] & 0xfd) | 0x01)
                    : (Flute ? ((_buffer[(int)Items.RandomizerFlute] & 0xfe) | 0x02) : (_buffer[(int)Items.RandomizerFlute] & 0xfc)));
                if (value && (_buffer[(int)Items.Flute] == (byte)GameState.FluteType.Inactive)) { _buffer[(int)Items.Flute] = (byte)GameState.FluteType.Active; }
                else if ((!value) && _buffer[(int)Items.Flute] == 0x03)
                {
                    _buffer[(int)Items.Boomerang] = Flute
                        ? (byte)GameState.FluteType.Inactive
                        : (byte)GameState.FluteType.NoFlute;
                }
            }
        }

        public bool Hookshot
        {
            get => _buffer[(int)Items.Hookshot] == 1;
            set => _buffer[(int)Items.Hookshot] = value ? (byte)1 : (byte)0;
        }

        public byte Bombs
        {
            get => _buffer[(int)Items.Bombs];
            set => _buffer[(int)Items.Bombs] = value;
        }

        public bool Mushroom
        {
            get => (_buffer[(int)Items.RandomizerPowder] & 0x20) == 0x20;
            set
            {
                _buffer[(int)Items.RandomizerPowder] = (byte)(value
                    ? _buffer[(int)Items.RandomizerPowder] | 0x20
                    : _buffer[(int)Items.RandomizerPowder] & 0xdf);
                if (value && (_buffer[(int)Items.Powder] == 0)) { _buffer[(int)Items.Powder] = 0x01; }
                else if ((!value) && _buffer[(int)Items.Powder] == 0x01)
                {
                    _buffer[(int)Items.Powder] = (byte)(Powder ? 0x02 : 0x00);
                }
            }
        }

        public bool Powder
        {
            get => (_buffer[(int)Items.RandomizerPowder] & 0x10) == 0x10;
            set
            {
                _buffer[(int)Items.RandomizerPowder] = (byte)(value
                    ? _buffer[(int)Items.RandomizerPowder] | 0x10
                    : _buffer[(int)Items.RandomizerPowder] & 0xef);
                if (value && (_buffer[(int)Items.Powder] == 0)) { _buffer[(int)Items.Powder] = 0x02; }
                else if ((!value) && _buffer[(int)Items.Powder] == 0x02)
                {
                    _buffer[(int)Items.Powder] = (byte)(Mushroom ? 0x01 : 0x00);
                }
            }
        }

        public bool FireRod
        {
            get => _buffer[(int)Items.FireRod] == 1;
            set => _buffer[(int)Items.FireRod] = value ? (byte)1 : (byte)0;
        }

        public bool IceRod
        {
            get => _buffer[(int)Items.IceRod] == 1;
            set => _buffer[(int)Items.IceRod] = value ? (byte)1 : (byte)0;
        }

        public bool Bombos
        {
            get => _buffer[(int)Items.Bombos] == 1;
            set => _buffer[(int)Items.Bombos] = value ? (byte)1 : (byte)0;
        }

        public bool Ether
        {
            get => _buffer[(int)Items.Ether] == 1;
            set => _buffer[(int)Items.Ether] = value ? (byte)1 : (byte)0;
        }

        public bool Quake
        {
            get => _buffer[(int)Items.Quake] == 1;
            set => _buffer[(int)Items.Quake] = value ? (byte)1 : (byte)0;
        }

        public bool Lamp
        {
            get => _buffer[(int)Items.Lamp] == 1;
            set => _buffer[(int)Items.Lamp] = value ? (byte)1 : (byte)0;
        }

        public bool Hammer
        {
            get => _buffer[(int)Items.Hammer] == 1;
            set => _buffer[(int)Items.Hammer] = value ? (byte)1 : (byte)0;
        }

        public bool BugNet
        {
            get => _buffer[(int)Items.BugNet] == 1;
            set => _buffer[(int)Items.BugNet] = value ? (byte)1 : (byte)0;
        }

        public bool Book
        {
            get => _buffer[(int)Items.Book] == 1;
            set => _buffer[(int)Items.Book] = value ? (byte)1 : (byte)0;
        }

        public bool RedCane
        {
            get => _buffer[(int)Items.RedCane] == 1;
            set => _buffer[(int)Items.RedCane] = value ? (byte)1 : (byte)0;
        }

        public bool BlueCane
        {
            get => _buffer[(int)Items.BlueCane] == 1;
            set => _buffer[(int)Items.BlueCane] = value ? (byte)1 : (byte)0;
        }

        public bool Cape
        {
            get => _buffer[(int)Items.Cape] == 1;
            set => _buffer[(int)Items.Cape] = value ? (byte)1 : (byte)0;
        }

        public bool Mirror
        {
            get => _buffer[(int)Items.Mirror] == 2;
            set => _buffer[(int)Items.Mirror] = value ? (byte)2 : (byte)0;
        }

        public GameState.GloveType Glove
        {
            get => (GameState.GloveType)_buffer[(int)Items.Glove];
            set => _buffer[(int)Items.Glove] = (byte)value;
        }

        public bool MoonPearl
        {
            get => _buffer[(int)Items.MoonPearl] == 1;
            set => _buffer[(int)Items.MoonPearl] = value ? (byte)1 : (byte)0;
        }

        public GameState.SwordType Sword
        {
            get => (GameState.SwordType)_buffer[(int)Items.Sword];
            set => _buffer[(int)Items.Sword] = (byte)value;
        }

        public GameState.ShieldType Shield
        {
            get => (GameState.ShieldType)_buffer[(int)Items.Shield];
            set => _buffer[(int)Items.Shield] = (byte)value;
        }

        public GameState.ArmorType Armor
        {
            get => (GameState.ArmorType)_buffer[(int)Items.Armor];
            set => _buffer[(int)Items.Armor] = (byte)value;
        }

        public GameState.BottleContentsType Bottle1
        {
            get => (GameState.BottleContentsType)_buffer[(int)Items.Bottle1];
            set => _buffer[(int)Items.Bottle1] = (byte)value;
        }

        public GameState.BottleContentsType Bottle2
        {
            get => (GameState.BottleContentsType)_buffer[(int)Items.Bottle2];
            set => _buffer[(int)Items.Bottle2] = (byte)value;
        }

        public GameState.BottleContentsType Bottle3
        {
            get => (GameState.BottleContentsType)_buffer[(int)Items.Bottle3];
            set => _buffer[(int)Items.Bottle3] = (byte)value;
        }

        public GameState.BottleContentsType Bottle4
        {
            get => (GameState.BottleContentsType)_buffer[(int)Items.Bottle4];
            set => _buffer[(int)Items.Bottle4] = (byte)value;
        }

        public GameStateReaderWriter([NotNull] ISNESConnector connector) => _connector = connector;

        private const uint INVENTORY_BASE = 0x7ef340;

        private enum Items : uint
        {
            Bow = (0x7ef340 - INVENTORY_BASE),
            RandomizerBow = (0x7ef38e - INVENTORY_BASE),
            Boomerang = (0x7ef341 - INVENTORY_BASE),
            RandomizerBoomerang = (0x7ef38c - INVENTORY_BASE),
            RandomizerFlute = (0x7ef38c - INVENTORY_BASE),
            RandomizerShovel = (0x7ef38c - INVENTORY_BASE),
            Hookshot = (0x7ef342 - INVENTORY_BASE),
            Bombs = (0x7ef343 - INVENTORY_BASE),
            RandomizerPowder = (0x7ef38c - INVENTORY_BASE),
            Powder = (0x7ef344 - INVENTORY_BASE),
            FireRod = (0x7ef345 - INVENTORY_BASE),
            IceRod = (0x7ef346 - INVENTORY_BASE),
            Bombos = (0x7ef347 - INVENTORY_BASE),
            Ether = (0x7ef348 - INVENTORY_BASE),
            Quake = (0x7ef349 - INVENTORY_BASE),
            Lamp = (0x7ef34a - INVENTORY_BASE),
            Hammer = (0x7ef34b - INVENTORY_BASE),
            Flute = (0x7ef34c - INVENTORY_BASE),
            BugNet = (0x7ef34d - INVENTORY_BASE),
            Book = (0x7ef34e - INVENTORY_BASE),
            Bottle = (0x7ef34f - INVENTORY_BASE),
            RedCane = (0x7ef350 - INVENTORY_BASE),
            BlueCane = (0x7ef351 - INVENTORY_BASE),
            Cape = (0x7ef352 - INVENTORY_BASE),
            Mirror = (0x7ef353 - INVENTORY_BASE),
            Glove = (0x7ef354 - INVENTORY_BASE),
            MoonPearl = (0x7ef357 - INVENTORY_BASE),
            Sword = (0x7ef359 - INVENTORY_BASE),
            Shield = (0x7ef35a - INVENTORY_BASE),
            Armor = (0x7ef35b - INVENTORY_BASE),
            Bottle1 = (0x7ef35c - INVENTORY_BASE),
            Bottle2 = (0x7ef35d - INVENTORY_BASE),
            Bottle3 = (0x7ef35e - INVENTORY_BASE),
            Bottle4 = (0x7ef35f - INVENTORY_BASE)
        }

        public bool Read()
        {
            return _connector.ReadBytes(INVENTORY_BASE, _buffer);
        }

        public bool Write()
        {
            //this will clobber stuff, fix at end - kat
            return _connector.WriteBytes(INVENTORY_BASE, _buffer);
        }
    }
}
