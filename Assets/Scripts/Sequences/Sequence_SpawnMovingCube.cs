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

        // Get random axis for moving cube

        // Set data container's moving cube reference

        // We define the waypoints of the moving cube
        DataContainer.MovingCubeDestination = topCubeMover.GetDestinations(DataContainer.CurrentBottomCube.transform.position + new Vector3(0f, DataContainer.CurrentBottomCube.transform.lossyScale.y, 0f));

        // The moving cube is spawned on one of its waypoints
        Vector3 spawnPos = DataContainer.MovingCubeDestination[0];

        topCubeMover.IncreaseSpeed();

        // Spawn moving cube
        DataContainer.CurrentMovingCube = cubeSpawner.spawnMovingCube(spawnPos, DataContainer.CurrentBottomCube.transform.localScale);

        // Change color
        colorManager.ChangeMaterial();
        DataContainer.CurrentMovingCube.GetComponent<MeshRenderer>().material = colorManager.CurrentMaterial;

        // Raise camera

        Vector3 camDestination = DataContainer.CurrentBottomCube.transform.position;


        // If the camera is still moving while the player stacked a new cube, 
        // we stop the current coroutine before starting a new one

        cameraManager.MoveCamera(camDestination, 0.75f);
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
