using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    float speedMultiplier = 1f;
    private float jumpingPower = 18f;
    private bool isFacingRight = true;
    public bool projectileRight = true;
    private bool isGrounded = true;
    public ParticleSystem speedEffects;


    public CollectableManager cm;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    void StartSpeedBoost(float multiplier)
    {
        StartCoroutine(SpeedBoostCoroutine(multiplier));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        speedEffects.Play();
        yield return new WaitForSeconds(5f);
        speedMultiplier = 1f;
        speedEffects.Stop();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * speedMultiplier, rb.velocity.y);
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

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            projectileRight = false;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            speedEffects.transform.localScale = localScale;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            cm.collectableCount++;
        }
        else if (other.gameObject.CompareTag("Powerup One"))
        {
            Destroy(other.gameObject);
            StartSpeedBoost(2);
            cm.collectableCount += 2;
        }
    }
}
