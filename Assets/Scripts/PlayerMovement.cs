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

    Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
        
        Flip();
    }

    public void StartSpeedBoost(float multiplier)
    {
        StartCoroutine(SpeedBoostCoroutine(multiplier));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        animator.SetBool("isSprinting", true);
        speedEffects.Play();
        yield return new WaitForSeconds(5f);
        speedMultiplier = 1f;
        animator.SetBool("isSprinting", false);
        speedEffects.Stop();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * speedMultiplier, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("Jump", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
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
}
