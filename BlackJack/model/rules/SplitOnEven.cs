using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SplitOnEven : IWinStrategy
    {
        private const int g_maxScore = 21;

        public string winRule(Player a_player, Dealer a_dealer, string[] gameWinner)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return gameWinner[0];
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return gameWinner[1];
            }
            else if (a_player.CalcScore() == a_dealer.CalcScore())
            {
                return gameWinner[2];
            }
            else if (a_player.CalcScore() > a_dealer.CalcScore())
            {

                return gameWinner[1];
            }
            else
            {
                return gameWinner[0];
            }
                

        }
    }
}
