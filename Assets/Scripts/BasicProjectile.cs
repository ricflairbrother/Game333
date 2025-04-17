using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Lifetime of the projectile in seconds
    public float lifetime = 3f;

    void Start()
    {
        // Destroy the projectile after lifetime seconds
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for collision with enemy objects
        if (collision.CompareTag("Enemy"))
        {
            // Implement logic when the projectile hits an enemy
            // e.g., reduce enemy health
            Debug.Log("Enemy hit!");
            Destroy(gameObject);
        }
    }
}