using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelController : MonoBehaviour
{
    private bool restart = false;
    public GameOver gameOver;
    public StartMenu start;
    public ScoreKeeping scoreKeeping;
    public int _finalScore = 0;
    // public Food _foodScore; 

    public void GameOver()
    {
        gameOver.Setup(_finalScore); 
    }

    public void StartMenu()
    {
        start.Setup();
    }


    public bool getGameStatus()
    {
        return restart;
    }

    public void setGameStatus(bool gameStatus)
    {
        restart = gameStatus;
    }

    private void Start()
    {
        // always start on start screen
        StartMenu();


    }
    // Update is called once per frame
    void Update()
    {
        if (getGameStatus())
        {
            // go to restart menu
            GameOver();
            print("go to restart menu");

        }

        scoreKeeping.Setup(_finalScore);


    }
}
