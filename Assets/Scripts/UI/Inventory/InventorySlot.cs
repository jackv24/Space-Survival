﻿/*
**  Author: Jack Vine
**
**  Controls each displayed inventory slot using UI events, and updates display
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //Reference to itself set by DisplayInventory when slot is created
    public DisplayInventory displayInventory;

    //The inventory index this slot displays
    public int index = 0;
    //The item in this slot
    [HideInInspector]
    private Item containingItem;

    //The image where the item in this slot is displayed
    private Image image;

    //Tooltip to update
    private ItemTooltip tooltip;

    void Awake()
    {
        //Image should be a component of the only child of this gameobject
        image = transform.GetChild(0).GetComponent<Image>();

        tooltip = ItemTooltip.instance;
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
        {
            image.color = Color.clear;
        }

        containingItem = item;

        displayInventory.RefreshText();
    }
    public Item GetItem() { return containingItem; } //Simply get the item

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Dragging with left click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (containingItem != null)
            {
                displayInventory.lastSlot = index;
                displayInventory.DraggingItem = containingItem;

                containingItem = null;

                image.sprite = null;
                image.color = Color.clear;

                //Make tooltip disappear while dragging
                OnPointerExit(eventData);
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Not implemented - needed for begin drag to work
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Dropping with left click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            displayInventory.currentSlot = index;
            SetItem(displayInventory.DraggingItem);

            //If there is now a containing item(null if there was no item being dragged to begin with)
            if (containingItem != null)
            {
                image.sprite = containingItem.inventorySprite;
                image.color = Color.white;
            }

            //Make tooltip appear on drop
            OnPointerEnter(eventData);
        }
    }

    //Control tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (containingItem)
        {
            tooltip.gameObject.SetActive(true);

            tooltip.UpdateData(containingItem);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
