using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_SpawnMovingCube : Sequence
{
    [SerializeField] CubeSpawner cubeSpawner;
    [SerializeField] TopCubeMover topCubeMover;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] UI_manager uiManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] ColorManager colorManager;

    public override void DoAction()
    {
        scoreManager.score++;
        uiManager.updateScore(scoreManager.score);

        topCubeMover.UpdateDataContainerMovingCubeDestination();

        topCubeMover.IncreaseSpeed();

        cubeSpawner.SpawnMovingCube();

        colorManager.ChangeMaterial();

        DataContainer.Instance.MovingCube.GetComponent<MeshRenderer>().material = colorManager.CurrentMaterial;

        cameraManager.MoveCamera();
    }

    public override Sequence ChooseNextSequence()
    {
        // Move cube and listen to input
        return Sequences[0];
    }

    public override void SetUp()
    {
        //
    }

}
