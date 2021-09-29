using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemDescriptionText;
    [SerializeField] private Image itemImage;
    [SerializeField] private ItemSpriteResizer itemSpriteResizer;
    public static ItemToolTip itemToolTipInstance;

    private void Start()
    {
        itemSpriteResizer = gameObject.GetComponentInChildren<ItemSpriteResizer>();
    }


    public void ResetToolTip()
    {
        itemNameText.text = null;
        itemDescriptionText.text = null;
        itemImage.sprite = null;
    }

    public void UpdateToolTip(Item item)
    {
        itemNameText.text = item.name;
        itemDescriptionText.text = item.Description;
        itemImage.sprite = item.Icon;
        itemSpriteResizer.ImageResize();
    }
}
