using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int progress = 0;
    public Slider progressSlider;

    public GameObject player;
    public Rigidbody2D playerRb;
    public GameObject gameOverScreen;
    public GameObject loadCanvas;
    public List<GameObject> checkpoints;
    public int currentCheckpointIndex;

    Vector2 checkpointPos;

    public static event Action OnRestart; 
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        loadCanvas.SetActive(true);
        currentCheckpointIndex = SceneTransition.checkpointNum;
        checkpointPos = checkpoints[currentCheckpointIndex].transform.position;
        player.transform.position = new Vector3(checkpointPos.x, checkpointPos.y, 0);
        playerRb = GetComponent<Rigidbody2D>();
        progress = 0;
        Fruit.OnFruitCollect += IncreaseProgressAmount;
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        OnRestart.Invoke();
        Time.timeScale = 1;
    }

    public void GameOverScreen()
    {
        SceneManager.LoadScene("GameOver");
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

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
        Debug.Log("nice");
    }
}
