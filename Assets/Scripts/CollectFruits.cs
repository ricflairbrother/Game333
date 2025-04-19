using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruits : MonoBehaviour
{
    public CollectableManager cm;
    public playerMovement pm;

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
            pm.StartSpeedBoost(2);
            cm.collectableCount += 2;
        }
    }
}
