using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private CharacterController charControll;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            charControll.Move(moveDirection.normalized * speed * Time.deltaTime);
            anim.SetBool("IsMove",true);
        }
        else
        {
            anim.SetBool("IsMove",false);
        }
    }
}
