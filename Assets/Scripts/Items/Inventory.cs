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
    public void Pickup(Item item)
    {
        int index = GetEmptySlot();

        items[index] = item;

        //Update the display of the slot this item is now in
        if (displayInventory)
        {
            displayInventory.slots[index].SetItem(item);
        }
    }
}
