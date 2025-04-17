using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    // Speed for moving the character
    public float speed = 5f;

    // Force applied when jumping
    public float jumpForce = 12f;

    // Rigidbody2D for handling physics
    private Rigidbody2D rb;

    // Check if character is on the ground
    private bool isGrounded;

    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input
        float horizontal = Input.GetAxis("Horizontal");
        // Set the Rigidbody2D velocity for horizontal movement
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Jump when on the ground and jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Set isGrounded to true when colliding with ground objects
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set isGrounded to false when leaving ground objects
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}