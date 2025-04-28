using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour, IItem
{
    public bool itemUsed = false;

    public void Collect()
    {
        if(itemUsed)
        {
            return;
        }
        Destroy(gameObject);
        itemUsed = true;
        SceneTransition.numOfObjectives += 1;
    }
}