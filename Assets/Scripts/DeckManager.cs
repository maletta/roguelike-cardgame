using System.Collections;
using System.Collections.Generic;
using NBESQ_Productions;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    public List<Card> allCards = new List<Card>();
    private int currentIndex = 0;

    // refactor variables
    public int startingHandSize = 6;
    public int maxHandSize;
    public int currentHandSize;
    private HandManager handManager;

    void Start()
    {
        //Load all card assets from the Resources folder
        Card[] cards = Resources.LoadAll<Card>("Cards");

        //Add the loaded cards to the allCards list
        allCards.AddRange(cards);

        handManager = FindObjectOfType<HandManager>();
        maxHandSize = handManager.maxHandSize;
        for (int i = 0; i < startingHandSize; i++)
        {
            Debug.Log($"Drawing Card");
            DrawCard(handManager);
        }
    }

    void Update()
    {
        if (handManager != null)
        {
            currentHandSize = handManager.cardsInHand.Count;
        }
    }


    // Draw the cards if isnt 0
    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
            return;

        if (currentHandSize < maxHandSize)
        {
            Card nextCard = allCards[currentIndex];
            handManager.AddCardToHand(nextCard);
            currentIndex = (currentIndex + 1) % allCards.Count;// move index to zero when current index == allCards.Count
        }
    }
}
