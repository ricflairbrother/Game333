using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameRestart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
