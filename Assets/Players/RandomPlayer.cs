using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RandomPlayer : AiPlayer
{
    public override bool HitOrStay(Hand theirHand, bool youAreBanker)
    {
        if (youAreBanker && hand.Value > theirHand.Value)
        {
            // Already won, so don't hit.
            return false;
        }
        else if (hand.Value <= 4)
        {
            return true;
        }
        else if (hand.Value >= 6)
        {
            return false;
        }
        else
        {
            // Hand Value is 5
            return GameManager.Instance.Random.Next() % 2 == 0;
        }
    }
}
