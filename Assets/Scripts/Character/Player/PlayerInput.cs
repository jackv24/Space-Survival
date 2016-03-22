/*
**  Author: Jack Vine
**
**  Gets input for the player character, and calls the required functions from
**  CharacterMove, which should be attached to the same GameObject
*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMove))]
public class PlayerInput : MonoBehaviour
{
    private Vector2 inputVector;

    private CharacterMove characterMove;

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
    }

    void Update()
    {
        //Get horizontal and vertical input
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");

        //If input is not zero, call character move function
        if (inputVector != Vector2.zero)
            characterMove.Move(inputVector.normalized);

        //Jump button is used to stop the player drifting in space
        if (Input.GetButton("Jump"))
            characterMove.Brake();
    }
}
