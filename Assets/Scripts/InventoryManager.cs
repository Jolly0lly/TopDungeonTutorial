using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public StorageData Storage => storage;
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();
    [SerializeField] private StorageData storage;

    private void Awake()
    {
        inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
        storage.onDataChanged.AddListener(LoadStorage);
        LoadStorage();
        gameObject.SetActive(false);
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
            inventorySlots[index].UpdateSlot(item);
            index++;
        }
    }

   
}


