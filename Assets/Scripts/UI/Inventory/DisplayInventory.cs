/*
**  Author: Jack Vine
**
**  Displays the inventory slots. Assumed a grid layout group exists.
**  Also controls the inventory through InventorySlot UI events
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //The prefab to instantiate for slots
    public GameObject slotPrefab;

    //Reference to the inventory (is public as any inventory can be displayed. If left blank, this is the player)
    public Inventory inventory;

    //The indexes of the last and current slots - for moving items between slots when clicked and dragged
    public int lastSlot = 0, currentSlot = 0;

    //Private reference to the item currently being dragged
    private Item draggingItem;
    public Item DraggingItem //Property performs logic when dragging item is set and gotten
    {
        get
        {
            Item item = draggingItem;
            //When the dragging item is gotten, that means it has been placed, and is therefore not being dragged anymore
            draggingItem = null;

            dragImage.color = Color.clear;

            inventory.items[currentSlot] = item;

            return item;
        }
        set
        {
            draggingItem = value;

            dragImage.sprite = draggingItem.inventorySprite;
            dragImage.color = Color.white;

            //If the dragging item is being set, it is being dragged and is no longer in an inventory slot
            inventory.items[lastSlot] = null;
        }
    }

    //Prefab to spawn for displaying dragged item
    public GameObject dragItemPrefab;
    private Image dragImage;

    void Start()
    {
        //If no inventory has been set, assume player
        if(!inventory)
            inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        //If there is an inventory (set or found)...
        if (inventory)
        {
            //Destroy any slots that already exist for some reason
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            //For every inventory slot, create a slot to display
            for (int i = 0; i < inventory.Slots; i++)
            {
                GameObject obj = Instantiate(slotPrefab);
                obj.transform.SetParent(transform, false);

                InventorySlot slot = obj.GetComponent<InventorySlot>();
                //Make sure slot has a reference to this script
                slot.displayInventory = this;
                //Set the corresponding inventory item to be displayed in this slot
                slot.SetItem(inventory.items[i]);
                slot.index = i;
            }
        }

        //If a drag item image does not exist
        if (!dragImage)
        {
            //Instantiate prefab...
            GameObject obj = Instantiate(dragItemPrefab);
            obj.transform.SetParent(GameObject.FindWithTag("Canvas").transform);
            obj.transform.localScale = Vector3.one;
            //...and get image
            dragImage = obj.GetComponent<Image>();
        }
    }

    void Update()
    {
        //If an item is being dragged
        if (draggingItem)
        {
            //Make it follow the mouse pointer
            dragImage.transform.position = Input.mousePosition;
        }
    }
}
