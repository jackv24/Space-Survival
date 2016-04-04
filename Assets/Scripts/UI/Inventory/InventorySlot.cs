/*
**  Author: Jack Vine
**
**  Controls each displayed inventory slot using UI events, and updates display
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    //Reference to itself set by DisplayInventory when slot is created
    public DisplayInventory displayInventory;

    //The inventory index this slot displays
    public int index = 0;
    //The item in this slot
    private Item containingItem;

    //The image where the item in this slot is displayed
    private Image image;

    void Awake()
    {
        //Image should be a component of the only child of this gameobject
        image = transform.GetChild(0).GetComponent<Image>();
    }

    //Setting the item in this slot, also update display
    public void SetItem(Item item)
    {
        if (item)
        {
            image.sprite = item.inventorySprite;
            image.color = Color.white;
        }
        else
            image.color = Color.clear;

        containingItem = item;
    }
    public Item GetItem() { return containingItem; } //Simply get the item

    //WHen the mouse is clicked over this slot
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //If there is an item in this slot, pick it up
            if (containingItem)
            {
                displayInventory.lastSlot = index;
                displayInventory.DraggingItem = containingItem;

                containingItem = null;

                image.sprite = null;
                image.color = Color.clear;
            }
            else //If there is no item, place the item that's being dragged
            {
                displayInventory.currentSlot = index;
                SetItem(displayInventory.DraggingItem);

                //If there is now a containing item (null if there was no item being dragged to begin with)
                if (containingItem)
                {
                    image.sprite = containingItem.inventorySprite;
                    image.color = Color.white;
                }
            }
        }
    }
}
