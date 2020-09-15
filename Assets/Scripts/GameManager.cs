using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    void Update()
    {
        if (playerStats.Lives <= 0 && !gameEnded)
            EndGame();
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}
