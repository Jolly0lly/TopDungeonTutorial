using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item Item => item;
    [SerializeField] private Image image;
    private Item item;
    private Outline invSlotOutline;
    private ItemSpriteResizer resizer;
    private bool invSlotOutlineEnabled = false;

    public void Start()
    {
        invSlotOutline = gameObject.GetComponent<Outline>();
    }

    private void Awake()
    {
        resizer = gameObject.GetComponent<ItemSpriteResizer>();
        
    }

    public void ResetSlot()
    {
        image.sprite = null;
        item = null;
        if (item == null)
            SetAlphaToZero();
    }

    public void UpdateSlot(Item item)
    {
        if(item != null)
        {
            image.sprite = item.Icon;
            this.item = item;
            if (resizer == null)
                Debug.Log(gameObject.name);
            resizer.ImageResize();
            SetAlphaBackToFull();
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

    public void HighlightSlotTrigger()
    {
        if(item != null)
        {
            invSlotOutlineEnabled = !invSlotOutlineEnabled;
            if (invSlotOutlineEnabled == true)
                invSlotOutline.enabled = true;
            else
                invSlotOutline.enabled = false;
        }
    }
        
   

}







