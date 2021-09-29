using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RemoveItemFromInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private StorageData storage;
    private InventoryManager invManager;
    private GameObject mouseOver;
    [SerializeField] private PlayerInventoryManager playerInvManager;
    


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
            
            InventorySlot slot;
            if (!mouseOver.TryGetComponent<InventorySlot>(out slot))
                return;

            Item itemInSlot = slot.Item;
            if (itemInSlot != null)
            {
                playerInvManager.OnObjectDropped(itemInSlot);
            }
        }
    }
}
        
            
            
