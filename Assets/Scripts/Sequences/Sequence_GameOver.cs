using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_GameOver : Sequence
{
    [SerializeField] UI_manager ui_manager;

    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ScoreManager scoreManager;

    [SerializeField] AudioManager audioManager;

    public override void doAction()
    {
        ui_manager.showUiElement(ui_manager.gameOverButton, true);
        //ui_manager.showUiElement(ui_manager.gameOverText, true);
        cubeSpawner.setRigidBdtoGravity(dataContainer.currentMovingCube);

        // New high score
        if (scoreManager.getHighScore() < scoreManager.score)
        {
            ui_manager.showUiElement(ui_manager.NewHighScoreText.gameObject, true);
            ui_manager.showUiElement(ui_manager.HighScoreText.gameObject, true);
            ui_manager.showUiElement(ui_manager.ScoreText.gameObject, false);

            audioManager.playSoundEffect(audioManager.newRecordSound);
        }

        scoreManager.setNewScoreHighScore();
        ui_manager.updateHighScore(scoreManager.getHighScore());
        


    }

    public override void setUp()
    {
        

    }

    public override Sequence chooseNextSequence()
    {
        // This sequence
        return sequences[0];
    }
}
