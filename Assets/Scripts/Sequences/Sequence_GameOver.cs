using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_GameOver : Sequence
{
    [SerializeField] UI_manager ui_manager;

    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ScoreManager scoreManager;

    public override void doAction()
    {
        ui_manager.showGameOverCanvas();
        cubeSpawner.setRigidBdtoGravity(dataContainer.currentMovingCube);

        if (scoreManager.getHighScore() < scoreManager.score)
        {
            ui_manager.showHighScoreText(true);
        }

        scoreManager.setNewScoreHighScore();
        ui_manager.updateHighScore(scoreManager.getHighScore());
        ui_manager.showHighScore(true);

        
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
