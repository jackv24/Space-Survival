﻿/*
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

    public List<InventorySlot> slots = new List<InventorySlot>();
    //The indexes of the last and current slots - for moving items between slots when clicked and dragged
    public int lastSlot = 0, currentSlot = 0;

    //Private reference to the item currently being dragged
    public Item draggingItem;

    //Prefab to spawn for displaying dragged item
    public GameObject dragItemPrefab;
    private Image dragImage;

    public Text amountText;

    void Start()
    {
        //If no inventory has been set, assume player
        if(!inventory)
            inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        //If there is an inventory (set or found)...
        if (inventory)
        {
            inventory.displayInventory = this;

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

                slots.Add(slot);
            }

            RefreshText();
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

    //Refreshes the display of inventory text for amount of slots
    public void RefreshText()
    {
        int fullSlots = 0;

        foreach (InventorySlot slot in slots)
        {
            if (slot.GetItem())
                fullSlots++;
        }

        amountText.text = fullSlots + "/" + slots.Count;
    }

    //Updates which item is being dragged
    public void SetDrag(Item item)
    {
        if (item)
        {
            draggingItem = item;

            dragImage.color = Color.white;
            dragImage.sprite = item.inventorySprite;
        }
        else
        {
            draggingItem = null;

            dragImage.color = Color.clear;
        }
    }
}
