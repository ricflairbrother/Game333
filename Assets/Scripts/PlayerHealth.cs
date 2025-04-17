using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public HealthManager hm;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            health -= damage;
            hm.DecreaseHealth(5);
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
