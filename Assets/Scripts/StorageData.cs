using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StorageData", menuName = "ScriptableObject/storageData")]
public class StorageData : ScriptableObject
{
    public List<Item> Items => items;
    [SerializeField] private List<Item> items = new List<Item>();
}
