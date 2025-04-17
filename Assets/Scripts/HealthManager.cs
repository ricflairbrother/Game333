using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int healthCount;
    [SerializeField]private TMP_Text healthDisplay;
    // Start is called before the first frame update

    private void OnGUI()
    {
        healthDisplay.text = healthCount.ToString();
    }

    // Update is called once per frame
    public void DecreaseHealth(int amount)
    {
        healthCount -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        healthCount += amount;
    }

    public void Update()
    {

    }
}