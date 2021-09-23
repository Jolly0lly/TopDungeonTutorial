using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayersInventoryManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private StorageData storage;
    private InventorySlot selectedSlot;
    private int selectedItemType;
    private Player player;
    private Weapon weapon;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        weapon = gameObject.transform.GetChild(0).GetComponent<Weapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectableItem item = collision.GetComponent<ICollectableItem>();
        if (item != null)
        {
            collision.gameObject.SetActive(false);
            storage.AddItemToInventory(item.GetItem());
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        selectedSlot = eventData.pointerClick.GetComponent<InventorySlot>();
        selectedItemType = CheckItemType(selectedSlot.Item);

        if (selectedItemType == 0)
            OnConsumableSelected(selectedSlot.Item);
        else if (selectedItemType == 1)
            OnWeaponSelected(selectedSlot.Item);
        else if (selectedItemType == 2)
            OnArmourSelected(selectedSlot.Item);

    }
    
    public int CheckItemType(Item item)
    {
        return item.Type;
    }

    public void OnArmourSelected(Item item)
    {
        player.SwapSprite(item);

    }

    public void OnWeaponSelected(Item item)
    {
        player.GetComponentInChildren<SpriteRenderer>().sprite = item.Icon;
        //weapon.weaponLevel = item.WeaponLevel;
    }

    public void OnConsumableSelected(Item item)
    {

    }

}
