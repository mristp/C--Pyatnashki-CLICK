using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pyatnashki
{
    public partial class Form15 : Form
    {
        Logic game;
        public Form15()
        {
            InitializeComponent();
            game = new Logic();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;            
            int position = Convert.ToInt16 (btn.Tag);
            //btn.Text = position.ToString();
            //MessageBox.Show(position.ToString());
            ////button(position).Text = position.ToString(); //// na Stage2
            game.shiftButton(position);
            refreshButtons();
            if (game.theEnd())
            {
                MessageBox.Show("Gotovo!");
                runIt();
            }
        }

        private Button button (int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void refreshButtons()
        {
            for (int position = 0; position < 16; position++)
            {
                int gotNum = game.getNumber(position);
                button(position).Text = gotNum.ToString();
                button(position).Visible = (gotNum > 0);
            }
                
        }

        private void runIt()
        {
            game.start();
            for (int j = 0; j < 400; j++) game.shiftButtonRandomize();
            refreshButtons();
        }
        private void Form15_Load(object sender, EventArgs e)
        {
            runIt();
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            runIt();
        }
    }
}
