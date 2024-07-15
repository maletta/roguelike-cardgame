using System.Collections;
using System.Collections.Generic;
using NBESQ_Productions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Card", menuName = "Card/Spell")] // cria um opção no menu create, 
public class Spell : Card
{
    public SpellType spellType;
    public List<AttributeTarget> attributeTarget;
    public List<int> attributeChangeAmount;
}
