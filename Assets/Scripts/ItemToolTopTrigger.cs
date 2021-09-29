using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToolTopTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject itemToolTipHolder;
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
        itemToolTip.UpdateToolTip(inventorySlot.Item);
        itemToolTipHolder.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemToolTipHolder.SetActive(false);
        itemToolTip.ResetToolTip();
    }
}