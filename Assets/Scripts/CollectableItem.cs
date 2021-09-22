using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    public Item Item => item;
    [SerializeField] private Item item;

    public Item GetItem()
    {
        return item;
    }
}
