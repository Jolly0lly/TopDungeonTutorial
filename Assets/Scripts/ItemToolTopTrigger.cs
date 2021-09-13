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
        Debug.Log("Mouse Enter");
        itemToolTip.UpdateToolTip(inventorySlot.Item);
        itemToolTipHolder.SetActive(true);
        itemToolTipHolder.transform.position = eventData.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
        itemToolTipHolder.SetActive(false);
        itemToolTip.ResetToolTip();
    }
}