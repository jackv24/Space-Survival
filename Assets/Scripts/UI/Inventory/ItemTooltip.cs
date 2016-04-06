/*
**  Author: Jack Vine
**
**  A singleton tooltip script. Updates the UI values of the tooltip when called externally,
**  and adjusts it's position to match the mouse pointer.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public static ItemTooltip instance;

    public Text itemName;
    public Text itemDescription;

    public Vector2 offset;

    void Awake()
    {
        //There should only ever be one tooltip, so this is fine
        instance = this;
    }

    void Start()
    {
        //Tooltip should start disabled
        gameObject.SetActive(false);
    }

    //Update after everything else, to prevent jerky-ness caused by it updates the next frame
    void LateUpdate()
    {
        transform.position = Input.mousePosition + (Vector3)offset;
    }

    //Called by the slot that is being moused over
    public void UpdateData(Item item)
    {
        itemName.text = item.itemName;
        itemDescription.text = item.description;
    }
}
