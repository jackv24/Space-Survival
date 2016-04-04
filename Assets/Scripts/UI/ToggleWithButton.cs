/*
**  Author: Jack Vine
**
**  Toggles the target with the button defined
*/

using UnityEngine;
using System.Collections;

public class ToggleWithButton : MonoBehaviour
{
    public GameObject target;

    public string button;

    public bool startEnabled = true;

    void Start()
    {
        target.SetActive(startEnabled);
    }

    void Update()
    {
        if (Input.GetButtonDown(button))
            target.SetActive(!target.activeSelf);
    }
}
