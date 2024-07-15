using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NBESQ_Productions
{

    //instancia esse script como um ScriptableObject
    // analogamente Card é uma classe que representa o domínio, de fato é um Card
    public class Card : ScriptableObject
    {
        public string cardName;
        public List<ElementType> cardTypes;
        public Sprite cardSprite;
        public string description;


    }

    public enum ElementType
    {
        Fire,
        Earth,
        Water,
        Dark,
        Light,
        Air
    }

    public enum AttackPattern
    {
        Single,
        Multitarget,
        Cross,
        Column,
        Row,
        TwoByTwo,
        FourByFour
    }

    public enum PriorityTarget
    {
        Close,
        Far,
        LeastCurrentHealth,
        MostCurrentHealth,
        MostMaxHealth,
        MostDamage
    }

    public enum SpellType
    {
        Buff,
        Debuff
    }

    public enum AttributeTarget
    {
        health,
        damage,
        range,
        attackPattern,
        damageType,
        priorityTarget,
    }

}