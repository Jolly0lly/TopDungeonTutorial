using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquippedItemHolder : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    [SerializeField] private Image image;
    [SerializeField] private PlayerInventoryManager playerInvManager;
    [SerializeField] private ItemSpriteResizer resizer;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item is WeaponItem)
            playerInvManager.OnWeaponDeselected();
        else if (item is ArmourItem)
            playerInvManager.OnArmourDeselected();
        item = null;
        ResetImage();
    }

    public void SetImage()
    {
       
        image.sprite = item.Icon;
        SetAlphaBackToFull();
        resizer.ImageResize();
    }

    public void ResetImage()
    {
        if (item == null)
        {
            image.sprite = null;
            SetAlphaToZero();
        }

    }

    public void SetAlphaToZero()
    {
        var tempcolor = image.color;
        tempcolor.a = 0;
        image.color = tempcolor;
    }

    public void SetAlphaBackToFull()
    {
        var tempcolor = image.color;
        tempcolor.a = 255;
        image.color = tempcolor;
    }

}
