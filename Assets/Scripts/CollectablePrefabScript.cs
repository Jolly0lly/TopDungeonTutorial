using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePrefabScript : MonoBehaviour, ICollectableItem
{
    private Item item;
    private SpriteRenderer spriteRenderer;

    private void UpdateCollectable()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.Icon;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        UpdateCollectable();
    }

    public Item GetItem()
    {
        return item;
    }
}
