using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {

        public enum Event
        {
            newgame,
            hit,
            stand,
            quit
        }

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }

        public int GetInput()
        {
            return System.Console.In.Read();
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(string a_dealerIsWinner)
        {

            System.Console.Write("GameOver: ");
            switch (a_dealerIsWinner)
            {
                case "dealer":
                    System.Console.WriteLine("Dealer Won!");
                    break;
                case "player":
                    System.Console.WriteLine("You Won!");
                    break;
                case "even":
                    System.Console.WriteLine("It's Even!");
                    break;
                default:
                    break;
            }
            
        }
        public void doOutput(IEnumerable<model.Card> dealerHand, IEnumerable<model.Card> playerHand, int dealerScore, int playerScore, bool gameOver, string isDealerWinner)
        {
            DisplayDealerHand(dealerHand, dealerScore);
            DisplayPlayerHand(playerHand, playerScore);
            if (gameOver)
            {
                DisplayGameOver(isDealerWinner);
            }
        }
        public bool GetActionNewGame(int input)
        {
            if (input == 'p')
            {
                return true;
            }
            return false;
        }

        public bool GetActionHit(int input)
        {
            if (input == 'h')
            {
                return true;
            }
            return false;
        }

        public bool GetActionStand(int input)
        {
            if (input == 's')
            {
                return true;
            }
            return false;
        }

        public bool GetActionQuit(int input)
        {
            if (input == 'q')
            {
                return true;
            }
            return false;
        }
    }
}
