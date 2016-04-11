/*
**  Author: Jack Vine
**
**  Stores the inventory, and contains inventory-related functions and variables
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //Inventory slots stored as a list of items, with empty items being set to null
    public List<Item> items = new List<Item>();

    //Call to update slot on display inventory (does not need to be assigned)
    public DisplayInventory displayInventory;

    public GameObject dropItemPrefab;

    //Slots property conveniently returns amount of inventory slots
    public int Slots
    {
        get { return items.Count; }
    }

    //Searches the list of item slots for an empty slot
    int GetEmptySlot()
    {
        for (int i = 0; i < Slots; i++)
        {
            if (items[i] == null)
                return i;
        }

        return -1;
    }

    //Called by the item which is picked up
    public void AddItem(Item item)
    {
        int index = GetEmptySlot();

        items[index] = item;

        //Update the display of the slot this item is now in
        if (displayInventory)
        {
            displayInventory.slots[index].SetItem(item);
        }
    }

    //Returns a bool if the item was used (chained from item.Use())
    public bool UseItem(int index)
    {
        bool used = false;

        if (items[index])
            used = items[index].Use(GetComponent<CharacterStats>());

        if (used)
            items[index] = null;

        return used;
    }

    public void DropItem(int index)
    {
        //CHeck if item exists at index
        if (items[index])
        {
            if (dropItemPrefab)
            {
                //TEMPORARY - items drop pos will be around character
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;

                //Create new DroppedItem
                GameObject obj = (GameObject)Instantiate(dropItemPrefab, pos, Quaternion.identity);

                //Update info
                DroppedItem drop = obj.GetComponent<DroppedItem>();
                drop.itemID = items[index].id;
                drop.UpdateInfo();
            }
            else
                Debug.Log("No dropItem prefab assigned to inventory!");

            //Remove from inventory
            items[index] = null;
        }
    }
}
