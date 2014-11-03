using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BlackJack.view;


namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;
        private const int g_maxScore = 21;

        public bool DoHit(model.Player a_dealer)
        {
            bool result = Validate(a_dealer);
            return result;
        }


        public bool Validate(model.Player a_dealer)
        {
            int[] cardScores = new int[(int)model.Card.Value.Count] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
            int dealerScore = 0;

            int aces = 0;

            foreach (Card card in a_dealer.GetHand())
            {
                if (card.GetValue() == Card.Value.Ace)
                {
                    aces++;
                }

                if (card.GetValue() != Card.Value.Hidden)
                {
                    dealerScore += cardScores[(int)card.GetValue()];
                }
            }

            if (dealerScore == g_hitLimit || dealerScore > g_maxScore)
            {
                foreach (Card card in a_dealer.GetHand())
                {
                    if (card.GetValue() == Card.Value.Ace && aces > 0)
                    {
                        dealerScore -= 10;
                        aces--;
                    }
                }
            }
            bool result = dealerScore < g_hitLimit;

            return result;
        }
    }
}
