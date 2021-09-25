using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController cc;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public bool isSprinting = false;
    public float sprintMultiplier = 2;

    public bool isCrouching = false;
    public float crouchHeight;
    public float standHeight;

    Vector3 velocity;
    
    void Update()
    {
        if(cc.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;                                   //adding -ve just to force player down to the ground
        }
        
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        //Basic Movement
        Vector3 move = transform.right * xInput + transform.forward * zInput;


        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Crouching
        if(Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if(isCrouching)
        {
            cc.height = crouchHeight;
        }
        else
        {
            cc.height = standHeight;
        }

        //Sprinting
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isSprinting)
        {
            move *= sprintMultiplier;
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;


        cc.Move(move * speed * Time.deltaTime);
        cc.Move(velocity * Time.deltaTime);

    }
}
