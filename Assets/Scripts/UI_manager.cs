using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField] GameObject gameOverButton;
    [SerializeField] GameObject gameOverText;
    [SerializeField] Text ScoreText;
    [SerializeField] Text HighScoreText;
    [SerializeField] Text NewHighScoreText;

    public void showGameOverCanvas()
    {
        gameOverButton.SetActive(true);
        gameOverText.SetActive(true);
    }

    public void updateScore(int score)
    {
        ScoreText.text = ""+score;
    }

    public void updateHighScore(int highScore)
    {
        HighScoreText.text = "" + highScore;
    }

    public void showHighScore(bool show)
    {
        HighScoreText.gameObject.SetActive(show);
    }

    public void showHighScoreText(bool show)
    {
        NewHighScoreText.gameObject.SetActive(show);
    }
}
