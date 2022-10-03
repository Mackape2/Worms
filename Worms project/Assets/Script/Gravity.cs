using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 gravitation;
    private void FixedUpdate()
    {
        //Have to implement the gravity in code because the character controller collides with the rigidbody
        //gravitation = new Vector3(0, 5, 0);
        //if (!characterController.isGrounded)
          //  gravitation += Physics.gravity;


    }
}
