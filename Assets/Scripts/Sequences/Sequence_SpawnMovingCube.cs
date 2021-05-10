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
        DataContainer.movingCubeDestination = topCubeMover.GetDestinations(DataContainer.currentBottomCube.transform.position + new Vector3(0f, DataContainer.currentBottomCube.transform.lossyScale.y, 0f));

        // The moving cube is spawned on one of its waypoints
        Vector3 spawnPos = DataContainer.movingCubeDestination[0];

        topCubeMover.IncreaseSpeed();

        // Spawn moving cube
        DataContainer.currentMovingCube = cubeSpawner.spawnMovingCube(spawnPos, DataContainer.currentBottomCube.transform.localScale);

        // Change color
        colorManager.ChangeMaterial();
        DataContainer.currentMovingCube.GetComponent<MeshRenderer>().material = colorManager.CurrentMaterial;

        

        // Raise camera

        Vector3 camDestination = DataContainer.currentBottomCube.transform.position + DataContainer.distCamBottomCube;


        // If the camera is still moving while the player stacked a new cube, 
        // we stop the current coroutine before starting a new one
        if (DataContainer.moveCamCoroutine != null)
            StopCoroutine(DataContainer.moveCamCoroutine);

        DataContainer.moveCamCoroutine = cameraManager.MoveCamera(DataContainer.cam, camDestination, 0.75f);

        StartCoroutine(DataContainer.moveCamCoroutine);
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
