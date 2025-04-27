using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    void Start()
    {
        SceneTransition.numOfLives = 3;
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
