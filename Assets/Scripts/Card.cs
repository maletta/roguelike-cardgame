using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NBESQ_Productions
{

    [CreateAssetMenu(fileName = "New Card", menuName = "Card")] // cria um opção no menu create, 
    //instancia esse script como um ScriptableObject
    // analogamente Card é uma classe que representa o domínio, de fato é um Card
    public class Card : ScriptableObject
    {
        public string cardName;
        public List<CardType> cardTypes;
        public int health;
        public int damageMin;
        public int damageMax;
        public Sprite cardSprite;
        public List<DamageType> damageTypes;

    }

    public enum CardType
    {
        Fire,
        Earth,
        Water,
        Dark,
        Light,
        Air
    }

    public enum DamageType
    {
        Fire,
        Earth,
        Water,
        Dark,
        Light,
        Air
    }

}