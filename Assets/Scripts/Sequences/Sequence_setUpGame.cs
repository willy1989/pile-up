using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_setUpGame : Sequence
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] UI_manager ui_manager;

    [SerializeField] CameraManager cameraManager;

    public override void SetUp()
    {
       
    }

    public override void DoAction()
    {
        // Set up camera distance
        ui_manager.updateHighScore(scoreManager.GetHighScore());
    }

    public override Sequence ChooseNextSequence()
    {
        // 0 - Start game
        return Sequences[0];
    }


}
