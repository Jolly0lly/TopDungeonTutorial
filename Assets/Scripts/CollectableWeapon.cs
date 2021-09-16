using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWeapon : Collectable
{
    [SerializeField] private WeaponItem weaponItem;
    [SerializeField] private StorageData storage;

    protected override void OnCollect()
    {
        base.OnCollect();
        gameObject.SetActive(false);
        storage.Items.Add(weaponItem);

    }

}
