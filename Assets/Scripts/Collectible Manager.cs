using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public int collectableCount;
    [SerializeField]private TMP_Text coinsDisplay;
    // Start is called before the first frame update

    private void OnGUI()
    {
        coinsDisplay.text = collectableCount.ToString();
    }

    // Update is called once per frame
    public void ChangeCoins(int amount)
    {
        collectableCount += amount;
    }

    public void Update()
    {

    }
}