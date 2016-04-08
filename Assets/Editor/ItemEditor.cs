/*
**  Author: Jack Vine
**
**  Custom inspector for Items (which are ScriptableObjects).
**  Makes editing items assets easier, and nicer.
*/

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //The item that this script is targeting. That is, the item that is selected in the inspector.
        Item item = (Item)target;

        item.id = EditorGUILayout.IntField("ID", item.id);
        EditorGUILayout.HelpBox(
            "The ID of this item in code. ID 0 is reserved for the INVALID object"
            , MessageType.Info);


        item.itemName = EditorGUILayout.TextField("Item Name", item.itemName);
        item.inventorySprite = (Sprite)EditorGUILayout.ObjectField("Sprite", item.inventorySprite, typeof(Sprite), false);
        EditorGUILayout.Space();

        item.type = (Item.Type)EditorGUILayout.EnumPopup("Type of item", item.type);
        EditorGUILayout.Space();

        if (item.type == Item.Type.CONSUMABLE)
        {
            //Consumable items usually effect stats, so the stat to effect should only be selectable if the item type is consumable
            item.statType = (Item.StatType)EditorGUILayout.EnumPopup("Stat to affect", item.statType);
        }

        item.power = EditorGUILayout.IntField("Power", item.power);
        item.cost = EditorGUILayout.IntField("Cost", item.cost);
        EditorGUILayout.Space();

        GUILayout.Label("Description");
        item.description = EditorGUILayout.TextArea(item.description, GUILayout.MinHeight(100f));
    }
}
