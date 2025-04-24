using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItem
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}