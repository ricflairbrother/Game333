using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneTransition.numOfObjectives < 4)
        {
            gameController.CantEndGame();
        }
        else if(SceneTransition.numOfObjectives >= 4)
        {
            gameController.CanEndGame();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.NoEndGame();
    }
}
