using System.Collections;
using System.Collections.Generic;
using NBESQ_Productions;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    public List<Card> allCards = new List<Card>();
    private int currentIndex = 0;

    void Start()
    {
        // Load all card assets from the Resources folder
        Card[] cards = Resources.LoadAll<Card>("Cards");

        // Add the loaded cards to the allCards list
        allCards.AddRange(cards);
    }


    // Draw the cards if isnt 0
    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
        {
            return;
        }

        Card nextCard = allCards[currentIndex];
        handManager.AddCardToHand(nextCard);

        Debug.Log($"allCards.Count={allCards.Count}; currentIndex={currentIndex}; nextIndex={currentIndex + 1 % allCards.Count}");
        currentIndex = currentIndex + 1 % allCards.Count; // move index to zero when current index == allCards.Count
    }
}
