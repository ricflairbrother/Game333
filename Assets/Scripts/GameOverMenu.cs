using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        SceneTransition.checkpointNum = 0;
        SceneTransition.numOfLives = 3;
    }
    public void OnRetryClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
