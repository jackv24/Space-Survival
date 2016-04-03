/*
**  Author: Jack Vine
**
**  Displays the inventory slots. Assumed a grid layout group exists.
*/

using UnityEngine;
using System.Collections;

public class DisplayInventory : MonoBehaviour
{
    public GameObject slotPrefab;

    void Start()
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        if (inventory)
        {
            int slotsCount = inventory.slots;

            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < slotsCount; i++)
            {
                GameObject obj = Instantiate(slotPrefab);
                obj.transform.SetParent(transform, false);
            }
        }
    }
}
