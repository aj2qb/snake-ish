using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeping : MonoBehaviour
{
    public TMP_Text _mainPointsText;
    public Snake mySnake;

    public void Setup(int score)
    {
        _mainPointsText.text = "Score: " + score.ToString();
    }

    public void Update()
    {
        if (mySnake.gameOver)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

    }
}
