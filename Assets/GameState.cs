using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum GameState
{
    NewHand,
    DealingCards,
    CheckingImmediateWinners,
    AskingIfPunterHits,
    AskingIfBankerHits,
    DeterminingWinner,
    HandOver,
}
