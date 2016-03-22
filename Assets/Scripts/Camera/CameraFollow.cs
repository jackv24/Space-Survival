/*
**  Author: Jack Vine
**
**  Follows a target (usually the player).
*/

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    //Target and associated rigidbody
    public Transform target;
    private Rigidbody2D targetBody;

    //Speed at which to lerp
    public float speed = 0.25f;
    //Velocity modifier
    public float velocity = 0.25f;

    private Vector3 targetPos;

    void Start()
    {
        //If there is no target, find the player
        if (!target)
            target = GameObject.FindWithTag("Player").transform;

        //If there is a target, get it's rigidbody2D
        if (target)
            targetBody = target.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        //If the target had a 2D rigidbody...
        if (targetBody)
        {
            //...move the cmaera ahead by velocity
            targetPos += new Vector3(targetBody.velocity.x, targetBody.velocity.y, 0) * velocity;
        }

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, targetPos, speed);
    }
}
