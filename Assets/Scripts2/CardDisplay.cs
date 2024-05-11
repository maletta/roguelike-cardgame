using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NBESQ_Productions;
using System;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public Image[] typeImages;
    private Color[] typeColors = {
        Color.red, // Fire
        new Color(0.8f,0.52f,0.24f), // Earth
        Color.blue, // Water
        Color.magenta, // Dark
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
        cardImage.color = typeColors[(int)cardData.cardTypes[0]];


        nameText.SetText(cardData.cardName);
        healthText.SetText(cardData.health.ToString());
        damageText.SetText($"{cardData.damageMin} - {cardData.damageMax}");

        // nameText.SetText(cardData.cardName);
        // healthText.SetText(cardData.health.ToString());
        // damageText.SetText($"{cardData.damageMin} - {cardData.damageMax}");

    }
}
