using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassChange : MonoBehaviour
{
    // public Vector3 centerOfMass2;
    public bool isAwake;
    private Rigidbody rb;
    private int direction;
    private Vector3 addDirection;
        private void Awake()
    {
        direction = Random.Range(1, 8);

        if (direction == 1)
        {
            addDirection = new Vector3(0.2f, 3.5f, 0f);
        }
        else if (direction == 2)
        {
            addDirection = new Vector3(0f, 3.5f, 0.2f);
        }
        else if (direction == 3)
        {
            addDirection = new Vector3(-0.2f, 3.5f, 0f);
        }
        else if (direction == 4)
        {
            addDirection = new Vector3(0f, 3.5f, -0.2f);
        }
        else if (direction == 5)
        {
            addDirection = new Vector3(0.2f, 3.5f, 0.2f);
        }
        else if (direction == 6)
        {
            addDirection = new Vector3(-0.2f, 3.5f, -0.2f);
        }
        else if (direction == 7)
        {
            addDirection = new Vector3(0.2f, 3.5f, -0.2f);
        }
        else if (direction == 8)
        {
            addDirection = new Vector3(-0.2f, 3.5f, 0.2f);
        }
        

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.centerOfMass = addDirection;
        rb.WakeUp();
        isAwake = !rb.IsSleeping();
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position + transform.rotation * centerOfMass2, 1f);
    // }
}
