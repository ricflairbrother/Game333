using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    Vector3 targetPos;
    Vector3 moveDirection;
    Rigidbody2D rb;

    void Start()
    {
        targetPos = pointB.position;
        rb = GetComponent<Rigidbody2D>();
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
}
