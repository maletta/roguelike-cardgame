using System.Collections.Generic;
using NBESQ_Productions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Card", menuName = "Card/Spell")]
public class Spell : Card
{
    public SpellType spellType;
    public List<AttibuteTarget> attributeTarget;
    public List<int> attributeChangeAmount;
}
