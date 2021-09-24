using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayersInventoryManager : MonoBehaviour//, IPointerClickHandler
{
    [SerializeField] private StorageData storage;
    private InventorySlot selectedSlot;
    private int selectedItemType;
    private Player player;
    private Weapon weapon;
    private GameObject weaponObject;
    private Item selectedItem;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        weapon = gameObject.transform.GetChild(0).GetComponent<Weapon>();
        weaponObject = gameObject.transform.GetChild(0).gameObject;
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

    public void OnArmourSelected(ArmourItem armourItem)
    {
        player.EquipArmour(armourItem);

    }
    public void OnArmourDeselected()
    {
        player.UnequipArmour();
    }

    public void OnWeaponSelected(WeaponItem weaponItem)
    {
        weaponObject.SetActive(true);
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaponItem.Icon;
        weapon.weaponLevel = weaponItem.WeaponLevel;
    }
    public void OnWeaponDeselected()
    {
        weaponObject.SetActive(false);
    }

    public void OnConsumableSelected(ConsumableItem consumableItem)
    {

    }



}
