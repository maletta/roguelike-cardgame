using System.Collections.Generic;
using NBESQ_Productions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Card", menuName = "Card/Character")]
public class Character : Card
{
    public int health;
    public int damageMin;
    public int damageMax;
    public List<ElementType> damageTypes;
    public GameObject prefab;
    public int range;
    public AttackPattern attackPattern;
    public PriorityTarget priorityTarget;
}
