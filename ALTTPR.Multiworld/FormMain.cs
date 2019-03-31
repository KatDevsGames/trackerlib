using System;
using System.Windows.Forms;
using ConnectorLib;

namespace ALTTPR.Multiworld
{
    public partial class FormMain : Form
    {
        //private readonly sd2snesConnectionManager _manager = new sd2snesConnectionManager();
        private readonly sd2snesConnector _connector = new sd2snesConnector();
        private readonly GameStateReaderWriter _reader_writer;

        public FormMain()
        {
            InitializeComponent();
            _reader_writer = new GameStateReaderWriter(_connector);
            comboSword.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _reader_writer.Read();
            checkRedCane.Checked = _reader_writer.RedCane;
            checkBlueCane.Checked = _reader_writer.BlueCane;
            checkCape.Checked = _reader_writer.Cape;
            checkMirror.Checked = _reader_writer.Mirror;
            checkBugNet.Checked = _reader_writer.BugNet;
            checkBook.Checked = _reader_writer.Book;
            checkLamp.Checked = _reader_writer.Lamp;
            checkHammer.Checked = _reader_writer.Hammer;
            checkShovel.Checked = _reader_writer.Shovel;
            checkFlute.Checked = _reader_writer.Flute;
            checkBombos.Checked = _reader_writer.Bombos;
            checkEther.Checked = _reader_writer.Ether;
            checkQuake.Checked = _reader_writer.Quake;
            checkFireRod.Checked = _reader_writer.FireRod;
            checkIceRod.Checked = _reader_writer.IceRod;
            checkBow.Checked = _reader_writer.Bow;
            checkSilvers.Checked = _reader_writer.SilverArrows;
            checkHookshot.Checked = _reader_writer.Hookshot;
            numericBombs.Value = _reader_writer.Bombs;
            checkBlueBoom.Checked = _reader_writer.BlueBoomerang;
            checkRedBoom.Checked = _reader_writer.RedBoomerang;
            checkMushroom.Checked = _reader_writer.Mushroom;
            checkPowder.Checked = _reader_writer.Powder;
            comboSword.SelectedIndex = (int)_reader_writer.Sword;
            comboBottle1.SelectedIndex = (int)_reader_writer.Bottle1;
            comboBottle2.SelectedIndex = (int)_reader_writer.Bottle2;
            comboBottle3.SelectedIndex = (int)_reader_writer.Bottle3;
            comboBottle4.SelectedIndex = (int)_reader_writer.Bottle4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _reader_writer.RedCane = checkRedCane.Checked;
            _reader_writer.BlueCane = checkBlueCane.Checked;
            _reader_writer.Cape = checkCape.Checked;
            _reader_writer.Mirror = checkMirror.Checked;
            _reader_writer.BugNet = checkBugNet.Checked;
            _reader_writer.Book = checkBook.Checked;
            _reader_writer.Lamp = checkLamp.Checked;
            _reader_writer.Hammer = checkHammer.Checked;
            _reader_writer.Shovel = checkShovel.Checked;
            _reader_writer.Flute = checkFlute.Checked;
            _reader_writer.Bombos = checkBombos.Checked;
            _reader_writer.Ether = checkEther.Checked;
            _reader_writer.Quake = checkQuake.Checked;
            _reader_writer.FireRod = checkFireRod.Checked;
            _reader_writer.IceRod = checkIceRod.Checked;
            _reader_writer.Bow = checkBow.Checked;
            _reader_writer.SilverArrows = checkSilvers.Checked;
            _reader_writer.Bottle1 = (GameState.BottleContentsType)comboBottle1.SelectedIndex;
            _reader_writer.Bottle2 = (GameState.BottleContentsType)comboBottle2.SelectedIndex;
            _reader_writer.Bottle3 = (GameState.BottleContentsType)comboBottle3.SelectedIndex;
            _reader_writer.Bottle4 = (GameState.BottleContentsType)comboBottle4.SelectedIndex;
            _reader_writer.Sword = (GameState.SwordType)comboSword.SelectedIndex;
            _reader_writer.Powder = checkPowder.Checked;
            _reader_writer.Mushroom = checkMushroom.Checked;
            _reader_writer.RedBoomerang = checkRedBoom.Checked;
            _reader_writer.BlueBoomerang = checkBlueBoom.Checked;
            _reader_writer.Bombs = (byte)numericBombs.Value;
            _reader_writer.Hookshot = checkHookshot.Checked;
            _reader_writer.Write();
        }
    }
}
