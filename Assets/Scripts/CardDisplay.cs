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
    public Image damageImage;

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


    void Start() // Start is called before the first frame update
    {

        this.UpdateCardDisplay();

        // Obtém todos os GameObjects filhos com o componente MeshRenderer
        TMP_Text[] renderers = GetComponentsInChildren<TMP_Text>();

        foreach (TMP_Text renderer in renderers)
        {
            Debug.Log("Found Renderer: " + renderer.gameObject.name);
        }
    }

    void Update() // Update is called once per frame
    {
    }

    public void UpdateCardDisplay()
    {
        // Update the main card image color based on the first card type
        // get the enum, then get the index  number of enum
        cardImage.color = cardColors[(int)cardData.cardTypes[0]];

        // set the first damageTypes type as damage image color
        damageImage.color = typeColors[(int)cardData.damageTypes[0]];

        // Update the text for current card
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
