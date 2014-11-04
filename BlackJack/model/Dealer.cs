using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        public Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinStrategy m_WinRule;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_WinRule = a_rulesFactory.GetWinRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public void GetNewCard(Player a_user) 
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(true);
            a_user.DealCard(c);
        }

        public bool Stand(Dealer a_dealer) 
        {
            if (m_deck != null) 
            {
                ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    m_deck.GetCard();
                    GetNewCard(a_dealer);
                }
                return true;
            }

            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                GetNewCard(a_player);

                return true;
            }
            return false;
        }

        public string IsDealerWinner(Player a_player, Dealer a_dealer)
        {
            string[] gameWinner = { "dealer", "player", "even" };
            return m_WinRule.winRule(a_player, a_dealer, gameWinner);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
