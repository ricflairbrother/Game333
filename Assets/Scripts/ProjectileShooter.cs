using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Reference to the projectile prefab
    public GameObject projectilePrefab;

    // Speed at which the projectile moves
    public float projectileSpeed = 10f;

    // Point where the projectile is spawned
    public Transform firePoint1;
    public Transform firePoint2; 

    public playerMovement pm;

    void Update()
    {
        // Check for input to fire a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        if(pm.projectileRight == true)
        {
            // Create a new instance of the projectile at the fire point
            GameObject projectile = Instantiate(projectilePrefab, firePoint1.position, firePoint1.rotation);

            // Get the Rigidbody2D component of the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
            // Apply velocity to the projectile to move it forward
            rb.velocity = firePoint1.right * projectileSpeed;
        }
        else if(pm.projectileRight == false)
        {
            // Create a new instance of the projectile at the fire point
            GameObject projectile = Instantiate(projectilePrefab, firePoint2.position, firePoint2.rotation);

            // Get the Rigidbody2D component of the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
            // Apply velocity to the projectile to move it forward
            rb.velocity = firePoint2.up * projectileSpeed;
        }
    }
}
