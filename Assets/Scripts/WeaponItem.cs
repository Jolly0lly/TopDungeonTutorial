using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObject/Items/WeaponItem")]
public class WeaponItem : Item
{
    public int WeaponLevel => weaponLevel;
    [SerializeField] private int damage;
    [SerializeField] private int weaponLevel;
   
}
