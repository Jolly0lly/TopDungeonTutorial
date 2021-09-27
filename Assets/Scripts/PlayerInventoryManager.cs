using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInventoryManager : MonoBehaviour//, IPointerClickHandler
{
    [SerializeField] private StorageData storage;
    private InventorySlot selectedSlot;
    private int selectedItemType;
    private Player player;
    private Weapon weapon;
    private GameObject weaponObject;
    [SerializeField] private GameObject collectableItemPrefab;
    [SerializeField] private GameObject collectablesHolder;
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
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }

    public void OnArmourDeselected()
    {
        player.UnequipArmour();
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }

    public void OnWeaponSelected(WeaponItem weaponItem)
    {
        weaponObject.SetActive(true);
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaponItem.Icon;
        weapon.weaponLevel = weaponItem.WeaponLevel;
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }
    public void OnWeaponDeselected()
    {
        weaponObject.SetActive(false);
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }

    public void OnConsumableSelected(ConsumableItem consumableItem)
    {

    }

    public void OnObjectDropped(Item item)
    {
        GameObject newCollectable = Instantiate(collectableItemPrefab, ObjectDropPosition(), Quaternion.identity, collectablesHolder.transform);
        newCollectable.GetComponent<CollectablePrefabScript>().SetItem(item);
        
    }


    private Vector3 ObjectDropPosition()
    {
        float objectSpawnPositionOffsetX = Random.Range(0.08f, 0.2f) * RandomPositiveOrNegative();
        float objectSpawnPositionOffsetY = Random.Range(0.08f, 0.2f) * RandomPositiveOrNegative();
        Vector3 objectSpawnPosition = new Vector3(player.transform.position.x + objectSpawnPositionOffsetX , player.transform.position.y + objectSpawnPositionOffsetY, player.transform.position.z);
        return objectSpawnPosition;
    }

    private int RandomPositiveOrNegative()
    {
        float random = Random.Range(0, 100);
        if (random < 50)
            return -1;
        else 
            return 1;
    }



}
