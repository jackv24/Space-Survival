/*
**  Author: Jack Vine
**
**  Turns this plane into a parallax background object. Controls movement speed and creating new instances.
*/

using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour
{
    //The amount of which the background follows the camera
    //1 is full follow, 0 is no follow, -ve values move faster than the camera (foreground effect)
    public float speed = 0;

    //The sorting layer for this object
    public string sortingLayer;

    //The main camera
    private Transform cam;
    //The position of the main camera (no z-axis)
    private Vector3 camFollowPos;

    private Vector3 initialPos;

    void Start()
    {
        //Change sorting layer for this object
        GetComponent<Renderer>().sortingLayerName = sortingLayer;

        cam = Camera.main.transform;

        //Make sure the object maintains it's original position relative to the camera
        initialPos = transform.position;
    }

    void Update()
    {
        //Get position of the camera (not on z-axis)
        camFollowPos = new Vector3(cam.position.x, cam.position.y, transform.position.z);
        //Change position of this object relative to the camera, based on speed.
        transform.position = camFollowPos * speed + initialPos;
    }
}
