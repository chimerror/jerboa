using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Shoe : MonoBehaviour
{
    public Card cardPrefab;
    private Stack<Card> shoe;

    public void Deal(Hand hand)
    {
        var card = shoe.Pop();
        card.faceUp = true;
        card.transform.SetParent(hand.cardsGroup.transform);
        Debug.Assert(hand.cards.Count < 3, "Attempted to deal to hand with 3 cards!");
        hand.cards.Add(card);
        shoe.Peek().gameObject.SetActive(true);
    }

    private void Start()
    {
        SetupShoe();
    }

    private void Update()
    {
        shoe.Peek().gameObject.SetActive(true);
    }

    private void SetupShoe()
    {
        var cardList = new List<Card>();
        AddDeck(cardList, Back.Red);
        AddDeck(cardList, Back.Red);
        AddDeck(cardList, Back.Red);
        AddDeck(cardList, Back.Blue);
        AddDeck(cardList, Back.Blue);
        AddDeck(cardList, Back.Blue);
        cardList.Shuffle();
        shoe = new Stack<Card>();
        foreach (var card in cardList)
        {
            shoe.Push(card);
        }
        shoe.Pop();
        shoe.Pop();
        shoe.Pop();
    }

    private void AddDeck(List<Card> cardList, Back back)
    {
        foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
        {
            foreach (var rank in Enum.GetValues(typeof(Rank)).Cast<Rank>())
            {
                var card = Instantiate(cardPrefab, transform);
                card.suit = suit;
                card.rank = rank;
                card.back = back;
                card.faceUp = false;
                cardList.Add(card);
            }
        }
    }
}
