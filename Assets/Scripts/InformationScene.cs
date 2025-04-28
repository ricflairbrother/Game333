using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void ReturnToMain()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
