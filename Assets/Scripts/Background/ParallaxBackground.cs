/*
**  Author: Jack Vine
**
**  Turns this plane into a parallax background object. Parallax is acheived by following the camera, and changing texture offset
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxBackground : MonoBehaviour
{
    //The amount of which the background follows the camera
    //1 is full follow, 0 is no follow, -ve values move faster than the camera (foreground effect)
    public float speed = 0;

    //The main camera
    private Transform cam;
    //The position of the main camera (no z-axis)
    private Vector3 camFollowPos;

    private List<MeshRenderer> renderers;

    void Start()
    {
        cam = Camera.main.transform;

        renderers = new List<MeshRenderer>(gameObject.GetComponentsInChildren<MeshRenderer>());
    }

    void Update()
    {
        //Get position of the camera (not on z-axis)
        camFollowPos = new Vector3(cam.position.x, cam.position.y, transform.position.z);

        //Follow the camera
        transform.position = camFollowPos;

        //Change offset of background
        foreach (MeshRenderer rend in renderers)
        {
            //Initialise offset vector
            Vector2 offset = Vector2.zero;

            //Get z rotation for orienting offsets
            float rotation = (int)transform.eulerAngles.z;

            //Check the common rotations 0, 90, 180, and 270
            if (rotation == 90)
                offset = new Vector2(camFollowPos.y * speed, -camFollowPos.x * speed) / 10;
            else if (rotation == 180)
                offset = new Vector2(-camFollowPos.x * speed, -camFollowPos.y * speed) / 10;
            else if (rotation == 270)
                offset = new Vector2(-camFollowPos.y * speed, camFollowPos.x * speed) / 10;
            else
                offset = new Vector2(camFollowPos.x * speed, camFollowPos.y * speed) / 10;

            //Set texture offset
            rend.material.SetTextureOffset("_MainTex", offset);
        }
    }
}
