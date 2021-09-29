using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelector : MonoBehaviour, IPointerClickHandler
{
    private InventorySlot selectedSlot;
    private int selectedItemType;
    [SerializeField] private Player player;
    private Item selectedItem;
    private PlayerInventoryManager playerInvManager;
    private bool weaponEquipped;
    private bool armourEquipped;

    private void Awake()
    {
        playerInvManager = player.GetComponent<PlayerInventoryManager>();
        // selectedSlot = gameObject.GetComponent<InventorySlot>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        selectedSlot = eventData.selectedObject.GetComponent<InventorySlot>();
        if (selectedSlot.Item != null)
        {
            selectedItem = selectedSlot.Item;
            Debug.Log(selectedItem.Icon.ToString());
            selectedItemType = selectedItem.Type;
            if (selectedItemType == 0)
            {
                playerInvManager.OnConsumableSelected(selectedItem as ConsumableItem);
            }

            else if (selectedItemType == 1)
            {


                playerInvManager.OnWeaponSelected(selectedItem as WeaponItem);
                //selectedSlot.HighlightSlotTrigger();

                //else

                //{
                //    playerInvManager.OnWeaponDeselected();
                //    selectedSlot.HighlightSlotTrigger();
                //}

            }
            else if (selectedItemType == 2)
            {
                playerInvManager.OnArmourSelected(selectedItem as ArmourItem);

                // selectedSlot.HighlightSlotTrigger();

                //else
                //{
                //    playerInvManager.OnArmourDeselected();

                //    selectedSlot.HighlightSlotTrigger();
                //}
            }
        }

    }
}



