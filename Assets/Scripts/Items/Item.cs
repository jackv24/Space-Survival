/*
**  Author: Jack Vine
**
**  The base item script, contains item information
*/

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public int id;

    public string name;
    public Sprite inventorySprite;

    public string description;

    public enum Type
    {
        NULL,
        BASIC,
        CONSUMABLE,
        WEAPON
    }

    public Type type;

    public int power;
    public int cost;

    //Default contructor makes sure that it is clear that a default item is not a valid game item, as it has no useful data
    public Item()
    {
        id = -1;

        name = "INVALID";
        description = "Something went wrong. You should never ever see one of these items.";

        //Null items are used for cases such as empty slots in the inventory
        type = Type.NULL;

        power = 0;
        cost = 0;
    }
}