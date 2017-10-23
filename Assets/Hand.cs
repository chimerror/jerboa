using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public Text handValue;

    public int Value
    {
        get
        {
            return cards.Select(c => (int)c.rank).Where(r => r <= 9).Sum() % 10;
        }
    }

    private void Update()
    {
        handValue.text = Value.ToString();
    }
}
