/*
**  Author: Jack Vine
**
**  Moves the player using rigidbody forces when called externally.
*/

using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    //The force which is applied from the thrusters
    public float thrusterForce = 10f;

    private Rigidbody2D body;

    private Vector2 moveVector;

    //Allows forces in FixedUpdate to be applied as a result of external input
    private bool gotInput = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    //Changed applied forces which move the character
    public void Move(Vector2 inputVector)
    {
        //Move vector is thruster force from input vector y
        moveVector = inputVector * thrusterForce;

        gotInput = true;
    }

    //Stops the character from drifting
    public void Brake()
    {
        //If the character is still drifting, apply required force to stop the character
        if (body.velocity != Vector2.zero)
            moveVector = -body.velocity.normalized * thrusterForce;

        gotInput = true;
    }

    void FixedUpdate()
    {
        //If input has been received
        if (gotInput)
        {
            //Apply the required force
            body.AddForce(moveVector, ForceMode2D.Force);

            //Reset input boolean
            gotInput = false;
        }
    }
}
