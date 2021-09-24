using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTrigger : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject itemToolTipHolder;
    private bool inventoryEnabled = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
            inventory.SetActive(true);
        else
        {
            inventory.SetActive(false);
            itemToolTipHolder.SetActive(false);
        }
    }
}
