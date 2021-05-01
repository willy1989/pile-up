using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField] GameObject gameOverButton;
    [SerializeField] GameObject gameOverText;
    [SerializeField] Text ScoreText; 

    public void showGameOverCanvas()
    {
        gameOverButton.SetActive(true);
        gameOverText.SetActive(true);
    }

    public void updateScore(int score)
    {
        ScoreText.text = ""+score;
    }
}
