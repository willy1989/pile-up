using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public void SetNewScoreHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore",0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }
}
