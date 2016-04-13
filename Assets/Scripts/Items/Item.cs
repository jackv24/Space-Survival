/*
**  Author: Jack Vine
**
**  ScriptableObject for items. This is what an item is - a collection of data.
**  Items in the world or actually a DroppedItem, containing a reference to an item,
**  and displaying data from that item.
*/

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName ="Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    //Identify items by ID, to make searching the database safer (does not rely on names, which are changed often)
    public int id;

    //Data to display in inventory tooltips and such
    public string itemName;
    
    public Sprite inventorySprite;

    public string description;

    //Actual item data (that is, data that affects how the item works)
    public enum Type
    {
        BASIC,
        CONSUMABLE,
        WEAPON
    }
    //The type of item, used to determine how an item is used
    public Type type;

    public enum StatType
    {
        NONE,
        HEALTH,
        OXYGEN,
        FOOD
    }
    public StatType statType;

    //How much the item costs to buy
    public int cost;
    //The power of the item (use case depends)
    public int power;

    //Returns a bool if the item was used
    public bool Use(CharacterStats stats)
    {
        if (type == Type.CONSUMABLE)
        {
            if (statType == StatType.HEALTH)
            {
                if (stats.health < stats.maxHealth)
                {
                    stats.AddHealth(power);
                    return true;
                }
            }
            if (statType == StatType.FOOD)
            {
                if (stats.food < stats.maxFood)
                {
                    stats.AddFood(power);
                    return true;
                }
            }
        }

        //If the item was not used, return false
        return false;
    }
}