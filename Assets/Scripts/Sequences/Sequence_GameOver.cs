using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_GameOver : Sequence
{
    [SerializeField] UI_manager ui_manager;

    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ScoreManager scoreManager;

    [SerializeField] AudioManager audioManager;

    public override void DoAction()
    {
        ui_manager.showUiElement(ui_manager.gameOverButton, true);
        cubeSpawner.SetRigidBdtoGravity(DataContainer.Instance.MovingCube);

        // New high score
        if (scoreManager.GetHighScore() < scoreManager.score)
        {
            ui_manager.showUiElement(ui_manager.NewHighScoreText.gameObject, true);
            ui_manager.showUiElement(ui_manager.HighScoreText.gameObject, true);
            ui_manager.showUiElement(ui_manager.ScoreText.gameObject, false);

            audioManager.PlaySoundEffect(audioManager.NewRecordSound);
        }

        scoreManager.SetNewScoreHighScore();
        ui_manager.updateHighScore(scoreManager.GetHighScore());
    }

    public override void SetUp()
    {
        //
    }

    public override Sequence ChooseNextSequence()
    {
        // This sequence
        return Sequences[0];
    }
}
