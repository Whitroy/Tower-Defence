using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            EndGame();
        }

        if (playerStats.Lives <= 0 && !GameIsOver)
            EndGame();
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);

        Debug.Log("Game Over!");
    }
}
