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
        Item item = (Item)target;

        item.id = EditorGUILayout.IntField("ID", item.id);
        EditorGUILayout.HelpBox(
            "The ID of this item in code. ID 0 is reserved for the INVALID object"
            , MessageType.Info);


        item.itemName = EditorGUILayout.TextField("Item Name", item.itemName);
        item.inventorySprite = (Sprite)EditorGUILayout.ObjectField("Sprite", item.inventorySprite, typeof(Sprite), false);
        EditorGUILayout.Space();

        EditorGUILayout.EnumPopup("Type", item.type);
        item.cost = EditorGUILayout.IntField("Cost", item.cost);
        item.power = EditorGUILayout.IntField("Power", item.power);
        EditorGUILayout.Space();

        GUILayout.Label("Description");
        item.description = EditorGUILayout.TextArea(item.description, GUILayout.MinHeight(100f));
    }
}
