using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public Sprite Icon => icon;
    public int Type => type;
    public string Description => description;

    [SerializeField] private int ID;
    [SerializeField] private int type; // 0 - consumable, 1 - weapon, 2 - armour
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;

}

    


   
