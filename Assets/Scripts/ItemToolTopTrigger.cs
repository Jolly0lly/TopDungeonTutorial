using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToolTopTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject itemToolTipDisplay;
    [SerializeField] private ItemToolTip itemToolTip;
    private InventorySlot inventorySlot;

    private void Start()
    {
        inventorySlot = gameObject.GetComponent<InventorySlot>();

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventorySlot.Item == null)
            return;
        Debug.Log("Mouse Enter");
        itemToolTip.UpdateToolTip(inventorySlot.Item);
        itemToolTipDisplay.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
        itemToolTipDisplay.SetActive(false);
        itemToolTip.ResetToolTip();
    }
}