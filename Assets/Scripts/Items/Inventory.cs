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

    //Slots property conveniently returns amount of inventory slots
    public int Slots
    {
        get { return items.Count; }
    }
}
