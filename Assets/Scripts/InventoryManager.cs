using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public StorageData Storage => storage;
    [SerializeField] private StorageData storage;
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();
    private static InventoryManager inventoryManagerInstance;

    private void Awake()
    {
        if (InventoryManager.inventoryManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        inventoryManagerInstance = this;

        inventorySlots = gameObject.transform.GetChild(0).GetComponentsInChildren<InventorySlot>().ToList();
        storage.onDataChanged.AddListener(LoadStorage);
        LoadStorage();
        gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        storage.onDataChanged.RemoveListener(LoadStorage);
    }

    public void LoadStorage()
    {
        inventorySlots.ForEach(slot => slot.ResetSlot());
        int index = 0;
        foreach (var item in storage.Items)
        {
            if (index > inventorySlots.Count)
                return;
            inventorySlots[index].UpdateSlot(item);
            index++;
        }
    }

    public void AddItemToInventory(Item item)
    {
        if (storage.Items.Count < inventorySlots.Count)
            storage.AddItemToInventory(item);
        else
            Debug.Log("inventory full");
    }

    public void RemoveItemFromInventory(Item item)
    {
        if (storage.Items.Contains(item))
            storage.RemoveItemFromInventory(item);
        else
            Debug.Log("You're trying to remove an item that doesn't exist in the inventory. This shouldn't even be possible");
    }



}


