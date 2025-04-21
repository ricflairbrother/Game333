using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progress = 0;
    public Slider progressSlider;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0;
        Fruit.OnFruitCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        progress += amount;
        progressSlider.value = progress;
        if(progress >= 100)
        {
            Debug.Log("Powerup!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
