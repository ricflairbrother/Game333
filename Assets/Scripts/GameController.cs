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
    public GameObject gameOverScreen;
    public GameObject loadCanvas;
    public List<GameObject> levels;
    public int currentLevelIndex = 0;

    public static event Action OnRestart; 
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        loadCanvas.SetActive(true);
        progress = 0;
        Fruit.OnFruitCollect += IncreaseProgressAmount;
        PlayerHealth.OnPlayerDied += GameOverScreen;
    }

    void GameOverScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        OnRestart.Invoke();
        LoadLevel(0);
        Time.timeScale = 1;
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

    void LoadLevel(int level)
    {
        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[level].gameObject.SetActive(true);

        player.transform.position = new Vector3(4, 6, 0);

        currentLevelIndex = level;
        progress = 0;
        progressSlider.value = 0;
    }

    void LoadNextLevel()
    {
        int nextLevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex + 1;
        LoadLevel(nextLevelIndex);
    }
}
