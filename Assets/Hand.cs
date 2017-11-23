using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public HorizontalLayoutGroup buttons;
    public HorizontalLayoutGroup cardsGroup;
    public Text handValue;

    public int Value
    {
        get
        {
            return cards.Select(c => (int)c.rank).Where(r => r <= 9).Sum() % 10;
        }
    }

    public void DiscardCards()
    {
        foreach (var card in cards)
        {
            card.gameObject.SetActive(false);
            Destroy(card.gameObject);
        }
        cards.Clear();
    }

    private void Update()
    {
        handValue.text = Value.ToString();
    }
}
