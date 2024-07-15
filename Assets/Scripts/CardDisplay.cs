using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NBESQ_Productions;
using System;
using System.Linq;

// CardDisplay representa a visualização do Card, controla e altera suas características visuais
public class CardDisplay : MonoBehaviour
{
    // All card elements
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public Image[] typeImages;
    public Image displayImage;
    public GameObject characterElements;
    public GameObject spellElements;
    public GameObject characterCardLabel;
    public GameObject spellCardLabel;
    public TMP_Text descriptionText;

    // Character card elements
    public TMP_Text healthText;
    public TMP_Text damageText;
    public Image damageImage;

    // Spell card elements
    public GameObject[] spellTypeLabels;
    public GameObject[] attributeTargetSymbols;
    public float attributeSymbolSpacing = 10f;
    public TMP_Text attributeChangeAmountText;

    private Color[] cardColors = {
        new Color(0.44f, 0f, 0f), // Fire
        new Color(0.8f, 0.52f, 0.24f), // Earth
        new Color(0.1f, 0.2f, 0.35f), // Water
        new Color(0.23f,0.06f,0.21f), // Dark
        new Color(0.54f, 0.55f, 039f), // Light
        new Color(0.38f, 0.51f, 0.55f), // Air
    };

    private Color[] typeColors = {
        Color.red, // Fire
        new Color(0.8f,0.52f,0.24f), // Earth
        Color.blue, // Water
        Color.black, // Dark
        Color.yellow, // Light
        Color.white, // Air
    };

    public void UpdateCardDisplay()
    {
        // All card changes

        // Update the main card image color based on the first card type
        // get the enum, then get the index  number of enum
        cardImage.color = cardColors[(int)cardData.cardTypes[0]];
        // Update the text for current card
        nameText.SetText(cardData.cardName);
        displayImage.sprite = cardData.cardSprite;
        descriptionText.SetText(cardData.description);

        for (int i = 0; i < typeImages.Length; i++)
        {
            if (i < cardData.cardTypes.Count)
            {
                typeImages[i].gameObject.SetActive(true);
                typeImages[i].color = typeColors[(int)cardData.cardTypes[i]];  // get the enum, then get the index  number of enum
            }
            else
            {
                typeImages[i].gameObject.SetActive(false);
            }
        }

        // Specific card changes
        if (cardData is Character characterCard)
        {
            UpdateDisplayCharacterCard(characterCard);
        }
        else if (cardData is Spell spellCard)
        {
            UpdateDisplaySpellCard(spellCard);
        }
    }

    private void UpdateDisplayCharacterCard(Character characterCard)
    {
        spellElements.SetActive(false);
        characterElements.SetActive(true);
        characterCardLabel.SetActive(true);
        // set the first damageTypes type as damage image color
        damageImage.color = typeColors[(int)characterCard.damageTypes[0]];
        // Update the text for current card
        healthText.SetText(characterCard.health.ToString());
        damageText.SetText($"{characterCard.damageMin} - {characterCard.damageMax}");
    }

    private void UpdateDisplaySpellCard(Spell spellCard)
    {
        characterElements.SetActive(false);
        spellElements.SetActive(true);
        spellCardLabel.SetActive(true);

        // Set correct spell type label
        foreach (GameObject label in spellTypeLabels)
        {
            label.SetActive(false);
        }
        spellTypeLabels[(int)spellCard.spellType].SetActive(true);

        // Reset and update attribute target symbols
        foreach (GameObject symbol in attributeTargetSymbols)
        {
            symbol.SetActive(false);
        }


        for (int i = 0; i < spellCard.attributeTarget.Count; i++)
        {
            GameObject currentSymbol = attributeTargetSymbols[(int)spellCard.attributeTarget[i]];
            currentSymbol.SetActive(true);
            float newYPosition = i * attributeSymbolSpacing;
            currentSymbol.transform.localPosition = new Vector3(0, newYPosition, 0);
        }

        // Display attribute change amounts
        attributeChangeAmountText.text = string.Join(", ", spellCard.attributeChangeAmount);

    }
}
