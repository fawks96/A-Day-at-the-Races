using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races2
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has " + Cash + " bucks";
        }

        public void ClearBet()
        {
            MyBet = null;
            MyLabel.Text = Name + " hasn't place a bet";
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount > Cash) return false;
            MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
            UpdateLabels();
            return true;
        }

        public void Collect(int Winner)
        {
            if (Winner == MyBet.Dog) Cash += MyBet.Amount;
            else Cash -= MyBet.Amount;
            UpdateLabels();
        }
    }
}
