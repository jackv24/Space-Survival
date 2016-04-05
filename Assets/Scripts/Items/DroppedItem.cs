/*
**  Author: Jack Vine
**
**  Displays a visual representation of an item in the game world.
*/

using UnityEngine;
using System.Collections;

public class DroppedItem : MonoBehaviour
{
    public int itemID = -1;

    private Item item;

    void Start()
    {
        item = ItemDatabase.instance.GetItem(itemID);

        GetComponent<SpriteRenderer>().sprite = item.inventorySprite;
        name = name + "_" + item.name;
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
