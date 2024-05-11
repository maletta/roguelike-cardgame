using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NBESQ_Productions;
using System;
using System.Linq;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public Image[] typeImages;
    private Color[] cardColors = {
        Color.red, // Fire
        new Color(0.8f,0.52f,0.24f), // Earth
        Color.blue, // Water
        new Color(0.2327043f,0.05781015f,0.2052875f), // Dark
        Color.yellow, // Light
        Color.cyan, // Air
    };

    private Color[] typeColors = {
        Color.red, // Fire
        new Color(0.8f,0.52f,0.24f), // Earth
        Color.blue, // Water
        new Color(0.47f,0,0.4f), // Dark
        Color.yellow, // Light
        Color.cyan, // Air
    };


    void Start() // Start is called before the first frame update
    {

        this.UpdateCardDisplay();
    }

    void Update() // Update is called once per frame
    {
    }

    public void UpdateCardDisplay()
    {
        // Update the main card image color based on the first card type
        // get the enum, then get the index  number of enum
        cardImage.color = cardColors[(int)cardData.cardTypes[0]];


        nameText.SetText(cardData.cardName);
        healthText.SetText(cardData.health.ToString());
        damageText.SetText($"{cardData.damageMin} - {cardData.damageMax}");

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

    }
}
