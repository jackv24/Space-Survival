/*
**  Author: Jack Vine
**
**  Holds a database of all items in the game.
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
        foreach (Item item in items)
        {
            if (item.id == id)
                return item;
        }

        return new Item();
    }
}
