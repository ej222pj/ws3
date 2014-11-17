using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    interface IView
    {
        void DisplayWelcomeMessage();
        int GetInput();
        bool GetActionNewGame(int input);
        bool GetActionHit(int input);
        bool GetActionStand(int input);
        bool GetActionQuit(int input);
        void DisplayCard(model.Card a_card);
        void doOutput(IEnumerable<model.Card> dealerHand, IEnumerable<model.Card> playerHand, int dealerScore, int playerScore, bool gameOver, bool a_dealerIsWinner);
    }
}
