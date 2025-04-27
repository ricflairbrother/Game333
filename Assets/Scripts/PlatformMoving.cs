using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    Vector3 targetPos;

    PlayerMovement playerMovement;
    Rigidbody2D rb;
    Vector3 moveDirection;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        targetPos = pointB.position;
        CalculateDirection();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, pointA.position) < 0.05f)
        {
            targetPos = pointB.position;
            CalculateDirection();
        }
        if(Vector2.Distance(transform.position, pointB.position) < 0.05f)
        {
            targetPos = pointA.position;
            CalculateDirection();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void CalculateDirection()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerMovement.isPlatform = true;
            playerMovement.platformRb = rb;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerMovement.isPlatform = false;
        }
    }
}