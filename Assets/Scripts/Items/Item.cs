/*
**  Author: Jack Vine
**
**  The base item component - everything that can be picked up needs this component
**  Contains item and item display information
*/

using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public string itemName = "Item";

    public Sprite inventorySprite;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Inventory>().Pickup(this);

            //Item is simply set inactive when "picked up" and reactivated when dropped
            gameObject.SetActive(false);
        }
    }
}
