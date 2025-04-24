using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaStar : MonoBehaviour
{
    public int starDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.TakeDamage(starDamage);

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}

