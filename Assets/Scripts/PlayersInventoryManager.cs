using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersInventoryManager : MonoBehaviour
{
    [SerializeField] private StorageData storage;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectableItem item= collision.GetComponent<ICollectableItem>();
        if (item != null)
        {
            collision.gameObject.SetActive(false);
            storage.AddItemToInventory(item.GetItem());
        }
            
    }


}
