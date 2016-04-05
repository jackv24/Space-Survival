/*
**  Author: Jack Vine
**
**  Holds a database of all items in the game. Items are scriptable objects.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;
    }

    public Item GetItem(int id)
    {
        //Iterate through all items in the database
        foreach (Item item in items)
        {
            //If a matching ID is found, return that item
            if (item.id == id)
                return item;
        }

        //If no match is found, return item 0 (index 0 should be the invalid object)
        return items[0];
    }
}
