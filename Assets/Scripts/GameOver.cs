using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentLivesText;
    public int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = SceneTransition.numOfLives;
        currentLivesText.text = $"X{currentLives}";
        StartCoroutine(GameRestart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");
    }
}
