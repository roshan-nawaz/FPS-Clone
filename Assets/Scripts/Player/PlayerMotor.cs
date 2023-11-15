using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float speed = 5f;
    [SerializeField] float gravityValue = -9.8f;
    [SerializeField] float jumpHeight = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        //when CharacterController is used no need of rb

        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    //takes input from inutmanger.cs and applies here
    public void PMoving(Vector2 input) 
    { 
        Vector3 moveDirection = Vector3.zero; 
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    } 

    public void PForce(Vector2 input)
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(isGrounded == true && playerVelocity.y < 0)
        {   
            playerVelocity.y = -2f;
        }
        //Debug.Log(playerVelocity);
    }

    public void PJump()
    {        
        /*
        if (jump.triggered || jump.ReadValue<sloat>() == 1)           //both if statements r same when using rb
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */
        if (isGrounded == true) 
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
    }
}
