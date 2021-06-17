using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody rb;
    private float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Move()
    {
        float speedX = 0;
        float speedZ = 0;
        float speedY = 0;
        if (Input.GetKey(KeyCode.A))
        {
            speedZ = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedZ = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedY = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            speedY = moveSpeed;
        }
        rb.velocity = new Vector3((float)(speedX), (float)(speedY), (float)(speedZ)).normalized * moveSpeed;
    }
}
