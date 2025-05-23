using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravity = -9.81f;
    Vector3 velocity;
    private bool isGrounded;
    public bool Walking;

    CharacterController characterController;
    Transform firePoint;

    //Referencias
    PlayerAnimationState animationState;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animationState = GetComponent<PlayerAnimationState>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reseta a gravidade quando no ch�o
        }

        if (Walking)
        {
            animationState.WalkAnimation();
        }
        else
        {
            animationState.IdleAnimation();
        }
    }

    void Move()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);
        Walking = move != Vector3.zero;

    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
