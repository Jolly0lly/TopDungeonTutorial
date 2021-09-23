using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObject/Items/ArmourItem")]
public class ArmourItem : Item
{
    [SerializeField] private int damageReduction;
}
