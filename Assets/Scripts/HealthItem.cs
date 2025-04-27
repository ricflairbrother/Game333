using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItem
{
    public PlayerHealth pHealth;
    public bool itemUsed = false;

    public void Collect()
    {
        if(itemUsed)
        {
            Debug.Log("Hey what the sigma");
            return;
        }
        Destroy(gameObject);
        itemUsed = true;
        if(pHealth.currentHealth >= 100)
        {
            pHealth.GainShield(25);
            return;
        }
        else if(pHealth.currentHealth < 100)
        {
            pHealth.GainHealth(25);
            return;
        }
    }
}