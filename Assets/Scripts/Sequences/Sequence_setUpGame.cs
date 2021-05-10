using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_setUpGame : Sequence
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] UI_manager ui_manager;


    public override void SetUp()
    {
       
    }

    public override void DoAction()
    {
        //Debug.Log("setup Sequence_gameStarts");

        // Set up camera distance
        DataContainer.distCamBottomCube = DataContainer.cam.position - DataContainer.currentBottomCube.transform.position;
        ui_manager.updateHighScore(scoreManager.GetHighScore());
    }

    public override Sequence ChooseNextSequence()
    {
        // 0 - Start game
        return Sequences[0];
    }


}
