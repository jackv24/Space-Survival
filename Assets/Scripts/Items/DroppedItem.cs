/*
**  Author: Jack Vine
**
**  Displays a visual representation of an item in the game world.
*/

using UnityEngine;
using System.Collections;

public class DroppedItem : MonoBehaviour
{
    //Initialise item ID to the nonexistent ID of -1
    public int itemID = -1;

    //The item that this DroppedItem represents
    private Item item;

    void Start()
    {
        item = ItemDatabase.instance.GetItem(itemID);

        GetComponent<SpriteRenderer>().sprite = item.inventorySprite;
        name = name + "_" + item.itemName;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Inventory>().Pickup(item);

            //TODO: Object pooling
            Destroy(gameObject);
        }
    }
}
