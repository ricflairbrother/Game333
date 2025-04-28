using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    void Start()
    {
        SceneTransition.numOfLives = 3;
        SceneTransition.objective1Collected = false;
        SceneTransition.objective2Collected = false;
        SceneTransition.objective3Collected = false;
        SceneTransition.objective4Collected = false;
        SceneTransition.objective5Collected = false;
        SceneTransition.objective6Collected = false;
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("Information");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
