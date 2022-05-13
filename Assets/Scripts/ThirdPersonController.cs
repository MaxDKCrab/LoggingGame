using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform camera;
    [SerializeField] private CharacterController charControll;
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private float jumpForce;
    private float turnSmoothVelocity;
    private Animator anim;
    private bool isGrounded;
    private Vector3 velocity;
    

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += jumpForce;
        }
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                charControll.Move(moveDirection.normalized * sprintSpeed * Time.deltaTime);
            }
            else
            {
                charControll.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
           
            anim.SetBool("IsMove",true);
        }
        else
        {
            anim.SetBool("IsMove",false);
        }

        velocity.y += gravity * Time.deltaTime;

        charControll.Move(velocity * Time.deltaTime);
        
        
        
        
    }
}
