using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    Vector3 targetPos;

    PlayerMovement playerMovement;
    Rigidbody2D rb;
    Vector2 moveDirection;

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
        Debug.Log(Vector2.Distance(transform.position, pointB.position));
        if(Vector2.Distance(transform.position, pointA.position) < 1f)
        {
            targetPos = pointB.position;
            CalculateDirection();
        }
        if(Vector2.Distance(transform.position, pointB.position) < 1f)
        {
            targetPos = pointA.position;
            CalculateDirection();
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void CalculateDirection()
    {
        Vector3 temp = (targetPos - transform.position);
        moveDirection = new Vector2(temp.x, temp.y).normalized;
    }

    private void Flip()
    {
        if(moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}