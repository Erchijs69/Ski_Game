using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration = 100, turnSpeed = 100, minSpeed = 0, maxSpeed = 1000;
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private LayerMask groundlayers;
    [SerializeField] private Transform groundTransform;
    
    private float speed = 0;
    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        speed += acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        Vector3 velocity = transform.forward * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    void Update()
    {

        if(Input.GetKey(leftInput) && transform.eulerAngles.y < 269)
        {
            transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0), Space.Self);
        }    
        if(Input.GetKey(rightInput) && transform.eulerAngles.y > 91) 
        {
            transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0), Space.Self);
        }
    }
}
