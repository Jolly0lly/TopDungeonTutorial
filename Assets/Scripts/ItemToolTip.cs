using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemDescriptionText;
    [SerializeField] private Image itemImage;
    

    public void ResetToolTip()
    {
        itemNameText.text = null;
        itemDescriptionText.text = null;
        itemImage.sprite = null;
    }

    public void UpdateToolTip(Item item)
    {
        Debug.Log(this.name);
        itemNameText.text = item.name;
        itemDescriptionText.text = item.Description;
        itemImage.sprite = item.Icon;
    }
}
