using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item Item => item;
    [SerializeField] private Image image;
    private Item item;

    public void ResetSlot()
    {
        image.sprite = null;
        item = null;
    }

    public void UpdateSlot(Item item)
    {
        image.sprite = item.Icon;
        this.item = item;
    }
}
