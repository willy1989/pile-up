using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_GameOver : Sequence
{
    [SerializeField] UI_manager ui_manager;

    [SerializeField] CubeSpawner cubeSpawner;

    public override void doAction()
    {
        //
    }

    public override void setUp()
    {
        ui_manager.showGameOverCanvas();
        cubeSpawner.setRigidBdtoGravity(dataContainer.currentMovingCube);
    }

    public override Sequence chooseNextSequence()
    {
        // This sequence
        return sequences[0];
    }
}
