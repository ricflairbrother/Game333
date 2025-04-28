using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem5 : MonoBehaviour, IItem
{
    public bool itemUsed = false;

    void Start()
    {
        if(SceneTransition.objective5Collected == true)
        {
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        if(itemUsed)
        {
            return;
        }
        SceneTransition.objective5Collected = true;
        Destroy(gameObject);
        itemUsed = true;
        SceneTransition.numOfObjectives += 1;
    }
}