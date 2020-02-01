using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races2
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Random myRandom = new Random();
        Guy[] guys = new Guy[3];
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            //Greyhound initialization
            
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width,
                Randomizer = myRandom
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = myRandom
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = myRandom
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = myRandom
            };

            //Guys initialization
            guys[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = JoeRadioButton,
                MyLabel = JoeLabel
            };
            guys[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyRadioButton = BobRadioButton,
                MyLabel = BobLabel
            };
            guys[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyRadioButton = AlRadioButton,
                MyLabel = AlLabel
            };


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDown1.Value;
            int dog = (int)numericUpDown2.Value;
            if (JoeRadioButton.Checked)
            {
                if (!guys[0].PlaceBet(amount, dog)) MessageBox.Show(guys[0].Name + " doesn't have enough buck");
            }
            else if (BobRadioButton.Checked)
            {
                if (!guys[1].PlaceBet(amount, dog)) MessageBox.Show(guys[1].Name + " doesn't have enough buck");

            }
            else if (AlRadioButton.Checked)
            {
                if (!guys[2].PlaceBet(amount, dog)) MessageBox.Show(guys[2].Name + " doesn't have enough buck");
            }
            else
            {
                MessageBox.Show("Please choose one guy to bet");
            }
        }

        private void JoeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (JoeRadioButton.Checked)
            {
                label1.Text = "Joe";
            }
        }

        private void BobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BobRadioButton.Checked)
            {
                label1.Text = "Bob";
            }
        }

        private void AlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AlRadioButton.Checked)
            {
                label1.Text = "Al";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Dog #" + i + " won the race!", "We have a winner");
                    for (int j = 0; j < 3; j++)
                    {
                        guys[j].Collect(i);
                    }
                    break;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
