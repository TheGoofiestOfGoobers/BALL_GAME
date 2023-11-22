using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private bool jump;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        jump = Input.GetButton("Jump");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, movevertical);

        rb.AddForce(movement * speed);

        Jump();
    }

    void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.45f);

        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}

