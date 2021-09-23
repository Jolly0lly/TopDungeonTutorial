using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObject/Items/ConsumableItem")]
public class ConsumableItem : Item
{
    [SerializeField] private int effect; // 0 - Heal, 1 - Increase damage dealt, 2 - Increase player movement speed, 3 - Increase player's defense
    [SerializeField] private float effectDuration;
}
