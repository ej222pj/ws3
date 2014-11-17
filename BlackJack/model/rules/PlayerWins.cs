using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWins : IWinStrategy
    {
        private const int g_maxScore = 21;

        public bool winRule(Player a_player, Dealer a_dealer) 
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return false;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_player.CalcScore() >= a_dealer.CalcScore()) 
            {
                return true;
            }
            return false;
          
        }
    }
}
