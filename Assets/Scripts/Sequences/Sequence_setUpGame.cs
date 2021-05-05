using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_setUpGame : Sequence
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] UI_manager ui_manager;


    public override void setUp()
    {
       
    }

    public override void doAction()
    {
        Debug.Log("setup Sequence_gameStarts");

        // Set up camera distance
        dataContainer.distCamBottomCube = dataContainer.cam.position - dataContainer.currentBottomCube.transform.position;
        ui_manager.updateHighScore(scoreManager.getHighScore());
    }

    public override Sequence chooseNextSequence()
    {
        // 0 - Spawn moving cube
        return sequences[0];
    }
}
