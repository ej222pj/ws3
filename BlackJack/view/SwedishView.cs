using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SwedishView : IView 
    {
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hej Black Jack Världen");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Skriv 'p' för att Spela, 'h' för nytt kort, 's' för att stanna 'q' för att avsluta\n");
        }
        public int GetInput()
        {
            return System.Console.In.Read();
        }
        public void DisplayCard(model.Card a_card)
        {
            if (a_card.GetColor() == model.Card.Color.Hidden)
            {
                System.Console.WriteLine("Dolt Kort");
            }
            else
            {
                String[] colors = new String[(int)model.Card.Color.Count]
                    { "Hjärter", "Spader", "Ruter", "Klöver" };
                String[] values = new String[(int)model.Card.Value.Count] 
                    { "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio", "tio", "knekt", "dam", "kung", "ess" };
                System.Console.WriteLine("{0} {1}", colors[(int)a_card.GetColor()], values[(int)a_card.GetValue()]);
            }
        }
        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Spelare", a_hand, a_score);
        }
        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Croupier", a_hand, a_score);
        }
        public void DisplayGameOver(string a_dealerIsWinner)
        {
            System.Console.Write("Slut: ");
            switch (a_dealerIsWinner) 
            {
                case "dealer":
                    System.Console.WriteLine("Croupiern Vann!");
                    break;
                case "player":
                    System.Console.WriteLine("Du vann!");
                    break;
                case "even":
                    System.Console.WriteLine("Det blev lika!");
                    break;
                default:
                    break;
            }
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Har: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Poäng: {0}", a_score);
            System.Console.WriteLine("");
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
