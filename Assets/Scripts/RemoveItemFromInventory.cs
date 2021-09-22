using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveItemFromInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private StorageData storage;
    private InventoryManager invManager;
    private GameObject mouseOver;
    


    private void Start()
    {
        invManager = gameObject.GetComponentInParent<InventoryManager>();
        storage = invManager.Storage;
        mouseOver = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = eventData.pointerEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (mouseOver == null)
                return;
            Item itemInSlot = mouseOver.GetComponent<InventorySlot>().Item;
            if(itemInSlot != null)
                storage.RemoveItemFromInventory(itemInSlot);
        }
    }
        
}
