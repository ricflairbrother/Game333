using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float speed = 5f;
    float horizontalMovement;
    bool isFacingRight = true;

    public bool canDash;
    public bool isDashing;
    public float dashSpeed = 20f;
    public float dashDuration = 1f;
    public float dashCooldown = 3f;
    TrailRenderer trailRenderer;

    public float jumpForce = 10f;
    public int jumpAmt = 1;
    int jumpsRemain;

    public float gravity = 2f;
    public float fallSpeedMax = 18f;
    public float fallSpeedMult = 2f;

    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    bool isGrounded;

    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask wallLayer;
    public float wallSlideSpeed = 2f;
    bool isWallSliding;

    bool isWallJumping;
    float wallJumpDirection;
    float wallJumpTime = 0.5f;
    float wallJumpTimer;
    public Vector2 wallJumpPower = new Vector2(100f, 10f);

    void Start()
    {
        canDash = true;
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("Magnitude", rb.velocity.magnitude);
        animator.SetBool("isWallSliding", isWallSliding);
        if(isDashing)
        {
            return;
        }
        GroundCheck();
        Gravity();
        WallSlide();
        WallJump();

        if(!isWallJumping)
        {
            rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
            Flip();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(context.performed && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;

        trailRenderer.emitting = true;
        float dashDirection = isFacingRight ? 1f : -1f;

        rb.velocity = new Vector2(dashDirection * dashSpeed, rb.velocity.y);

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = new Vector2(0f, rb.velocity.y);

        isDashing = false;
        trailRenderer.emitting = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(jumpsRemain > 0)
        {
            if(context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsRemain--;
                animator.SetTrigger("Jump");
            }
            else if(context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                jumpsRemain--;
                animator.SetTrigger("Jump");
            }
        }

        if(context.performed && isWallSliding)
        {
            isWallJumping = true;
            isWallSliding = false;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
            animator.SetTrigger("Jump");

            if(transform.localScale.x != wallJumpDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 ls = transform.localScale;
                ls.x *= -1f;
                transform.localScale = ls;
            }
            Invoke(nameof(CancelWallJump), wallJumpTime + 0.1f);
            
        }
    }

    private void Gravity()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = gravity * fallSpeedMult;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -fallSpeedMax));
        }
        else
        {
            rb.gravityScale = gravity;
        }
    }

    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, wallLayer);
    }

    private void WallSlide()
    {
        if(!isGrounded & WallCheck() & horizontalMovement != 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -wallSlideSpeed));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpTimer = wallJumpTime;

            CancelInvoke(nameof(CancelWallJump));
        }
        else if(wallJumpTimer > 0f)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }

    private void CancelWallJump()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if(isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void GroundCheck()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemain = jumpAmt;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallCheckPos.position, wallCheckSize);
    }
}
