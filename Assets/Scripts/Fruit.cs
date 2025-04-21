using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IItem
{
    public static event Action<int> OnFruitCollect;
    public int worth = 5;

    public void Collect()
    {
        OnFruitCollect.Invoke(worth);
        Destroy(gameObject);
    }
}
