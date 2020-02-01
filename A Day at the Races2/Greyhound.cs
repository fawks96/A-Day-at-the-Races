using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races2
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            int step = Randomizer.Next(5, 10);
            Location += step;
            MyPictureBox.Left += step;
            if (Location >= RacetrackLength) return true;
            return false;
        }

        public void TakeStaringPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
