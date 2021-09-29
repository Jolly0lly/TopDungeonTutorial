using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInventoryManager : MonoBehaviour
{
    //[SerializeField] private StorageData storage;
    [SerializeField] private InventoryManager invManager;
    private Player player;
    private Weapon weapon;
    private GameObject weaponObject;
    private Vector3 droppedObjectPosition;
    [SerializeField] private GameObject collectableItemPrefab;
    [SerializeField] private GameObject collectablesHolder;
    [SerializeField] private EquippedItemHolder eqArmourHolder;
    [SerializeField] private EquippedItemHolder eqWeaponHolder;
    [SerializeField] private float minRadius = 0.08f;
    [SerializeField] private float maxRadius = 0.2f;
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
            invManager.AddItemToInventory(item.GetItem());
        }
    }

    public void OnArmourSelected(ArmourItem armourItem)
    {
        player.EquipArmour(armourItem);
        if (eqArmourHolder.item != null)
            invManager.AddItemToInventory(eqArmourHolder.item);
        invManager.RemoveItemFromInventory(armourItem);
        eqArmourHolder.item = armourItem;
        eqArmourHolder.SetImage();
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }

    public void OnArmourDeselected()
    {
        player.UnequipArmour();
        invManager.AddItemToInventory(eqArmourHolder.item);
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }

    public void OnWeaponSelected(WeaponItem weaponItem)
    {
        weaponObject.SetActive(true);
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaponItem.Icon;
        weapon.weaponLevel = weaponItem.WeaponLevel;
        invManager.RemoveItemFromInventory(weaponItem);
        if (eqWeaponHolder.item != null)
            invManager.AddItemToInventory(eqWeaponHolder.item);
        eqWeaponHolder.item = weaponItem;
        eqWeaponHolder.SetImage();
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }
    public void OnWeaponDeselected()
    {
        weaponObject.SetActive(false);
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        invManager.AddItemToInventory(eqWeaponHolder.item);
        GameManager.instance.characterMenu.onMenuDataChanged.Invoke();
    }

    public void OnConsumableSelected(ConsumableItem consumableItem)
    {

    }

    public void OnObjectDropped(Item item)
    {
        if (ObjectNotCollidingPosition() == false)
            return;
        GameObject newCollectable = Instantiate(collectableItemPrefab, droppedObjectPosition, Quaternion.identity, collectablesHolder.transform);
        newCollectable.GetComponent<CollectablePrefabScript>().SetItem(item);
        invManager.RemoveItemFromInventory(item);

    }


    private Vector3 RandomizedObjectDropPosition(float MinRadius, float MaxRadius)
    {

        Vector3 randomPositionInRing = Random.insideUnitCircle.normalized * Random.Range(MinRadius, MaxRadius);
        Vector3 objectSpawnPosition = player.transform.position + randomPositionInRing;

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

    private bool ObjectNotCollidingPosition()
    {
        droppedObjectPosition = RandomizedObjectDropPosition(minRadius, maxRadius);
        Collider2D[] hit = new Collider2D[10];
        hit = Physics2D.OverlapBoxAll(droppedObjectPosition, collectableItemPrefab.GetComponent<BoxCollider2D>().size, 0, LayerMask.GetMask("Actors", "BlockingObjects"));
        int i = 0;
        while (hit.Length != 0 && i < 100)
        {

            droppedObjectPosition = RandomizedObjectDropPosition(minRadius, maxRadius);
            hit = Physics2D.OverlapBoxAll(droppedObjectPosition, collectableItemPrefab.GetComponent<BoxCollider2D>().size, 0, LayerMask.GetMask("Actors", "BlockingObjects"));
            i++;
        }

        if (i >= 100)
            return false;

        return true;
    }
}
