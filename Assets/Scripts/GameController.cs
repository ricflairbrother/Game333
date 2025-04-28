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

    public int numFruitsNeeded;
    public PlayerShoot playerShoot; 
    public TMPro.TextMeshProUGUI numFruitsNeededText;
    public TMPro.TextMeshProUGUI ammoCountText;
    public float countOfAmmo;
    public TMPro.TextMeshProUGUI livesRemainingText;
    public int lifeNum;

    Vector2 checkpointPos;

    public static event Action OnRestart; 
    // Start is called before the first frame update
    void Start()
    {
        lifeNum = SceneTransition.numOfLives;
        countOfAmmo = playerShoot.ammoCount;
        livesRemainingText.text = $"X{lifeNum}";
        ammoCountText.text = $"X{countOfAmmo}";
        gameOverScreen.SetActive(false);
        loadCanvas.SetActive(true);
        numFruitsNeeded = 4;
        currentCheckpointIndex = SceneTransition.checkpointNum;
        checkpointPos = checkpoints[currentCheckpointIndex].transform.position;
        player.transform.position = new Vector3(checkpointPos.x, checkpointPos.y, 0);
        playerRb = GetComponent<Rigidbody2D>();
        progress = 0;
        Fruit.OnFruitCollect += IncreaseProgressAmount;
    }

    void Update()
    {
        numFruitsNeeded = 4 - SceneTransition.numOfObjectives;
        countOfAmmo = playerShoot.ammoCount;
        DisplayAmmo();
    }

    public void DisplayAmmo()
    {
        if(countOfAmmo <=0 )
        {
            ammoCountText.text = $"Reloading";
        }
        else if(countOfAmmo > 0)
        {
            ammoCountText.text = $"X{countOfAmmo}";
        }
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

    public void CantEndGame()
    {
        if(SceneTransition.numOfObjectives == 3)
        {
            numFruitsNeededText.text = $"You need {numFruitsNeeded} more fruit!";
            gameOverScreen.SetActive(true);
        }
        else
        {
            numFruitsNeededText.text = $"You need {numFruitsNeeded} more fruits!";
            gameOverScreen.SetActive(true);
        }

    }

    public void CanEndGame()
    {
        SceneManager.LoadScene("GameOverMenu");
    }
    
    public void NoEndGame()
    {
        gameOverScreen.SetActive(false);
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
