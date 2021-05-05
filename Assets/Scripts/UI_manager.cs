using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public GameObject gameOverButton;
    public GameObject gameOverText;
    public Text ScoreText;
    public Text HighScoreText;
    public Text NewHighScoreText;
    public Text StartGameText;

    public void updateScore(int score)
    {
        ScoreText.text = ""+score;
    }

    public void showUiElement(GameObject go, bool show)
    {
        go.SetActive(show);
    }

    public void updateHighScore(int highScore)
    {
        HighScoreText.text = "" + highScore;
    }

   
}
