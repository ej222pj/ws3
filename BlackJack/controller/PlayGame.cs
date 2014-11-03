using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BlackJack.model;
using BlackJack.model.rules;

namespace BlackJack.controller
{
    class PlayGame : IDealCard
    {
        private model.Game a_game;
        private view.IView a_view;
        private model.rules.SoftSeventeenHitStrategy a_input;

        public PlayGame(model.Game game, view.IView view)
        {
            a_game = game;
            a_view = view;
        }
        
        public bool Play()
        {
            a_view.DisplayWelcomeMessage();
            doOutput(a_game.IsGameOver());

            int input = a_view.GetInput();
            

            if (a_view.GetActionNewGame(input) == true)
            {
                a_game.NewGame();
            }
            else if (a_view.GetActionHit(input) == true)
            {
                a_game.Hit();
            }
            else if (a_view.GetActionStand(input) == true)
            {
                a_game.Stand();
            }

            return a_view.GetActionQuit(input) == false;           
        }

        public void DealCard() 
        {
            a_view.DisplayWelcomeMessage();
            doOutput(a_game.IsGameOver());
            System.Threading.Thread.Sleep(15);
        }

        public void doOutput(bool isGameOver)
        {
            if (isGameOver == true)
            {
                a_view.doOutput(a_game.GetDealerHand(), a_game.GetPlayerHand(), a_game.GetDealerScore(), a_game.GetPlayerScore(), true, a_game.IsDealerWinner());
            }
            else
            {
                a_view.doOutput(a_game.GetDealerHand(), a_game.GetPlayerHand(), a_game.GetDealerScore(), a_game.GetPlayerScore(), false, "dealer");
            }
        }
    }
}
