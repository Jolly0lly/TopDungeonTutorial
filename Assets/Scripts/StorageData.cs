using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "StorageData", menuName = "ScriptableObject/storageData")]
public class StorageData : ScriptableObject
{
    public List<Item> Items => items;
    [SerializeField] private List<Item> items = new List<Item>();
    public UnityEvent onDataChanged = new UnityEvent();
    public UnityEvent onItemSelected = new UnityEvent();

    public void AddItemToInventory(Item item)
    {
        items.Add(item);
        onDataChanged.Invoke();
    }

    public void RemoveItemFromInventory(Item item)
    {
        items.Remove(item);
        onDataChanged.Invoke();
    }
}
