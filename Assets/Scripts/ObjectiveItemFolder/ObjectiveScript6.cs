using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem6 : MonoBehaviour, IItem
{
    public bool itemUsed = false;

    void Start()
    {
        if(SceneTransition.objective6Collected == true)
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
        SceneTransition.objective6Collected = true;
        Destroy(gameObject);
        itemUsed = true;
        SceneTransition.numOfObjectives += 1;
    }
}