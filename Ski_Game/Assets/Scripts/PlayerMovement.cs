using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration = 100, turnSpeed = 100, minSpeed = 0, maxSpeed = 1000, minAcceleration = 200, maxAcceleration = 1000;
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundTransform;
    
    private float speed = 0;
    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float angle = Mathf.Abs(transform.eulerAngles.y - 180);
        acceleration = Remap(0, 90, maxAcceleration, minAcceleration, angle);
        speed += acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        Vector3 velocity = transform.forward * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private float Remap(float oldMin, float oldmax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldmax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }

    void Update()
    {
        bool isGrounded= Physics.Linecast(transform.position, groundTransform.position, groundLayers);
        if(isGrounded)
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

    
}
