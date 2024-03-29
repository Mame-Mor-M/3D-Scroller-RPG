using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;


    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("ITEM ADDED");
        }
        else
        {
            Debug.Log("NOOOOOOOOOOOOOOO");
        }
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("USING ITEM: " + receivedItem);
        }
        else
        {
            Debug.Log("NOTHING TO USE");
        }
    }
}
