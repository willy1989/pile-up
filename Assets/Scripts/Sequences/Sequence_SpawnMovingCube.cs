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

    public override void doAction()
    {
        scoreManager.score++;
        uiManager.updateScore(scoreManager.score);

        // Get random axis for moving cube

        // Set data container's moving cube reference

        // We define the waypoints of the moving cube
        dataContainer.movingCubeDestination = topCubeMover.getDestinations(dataContainer.currentBottomCube.transform.position + new Vector3(0f, dataContainer.currentBottomCube.transform.lossyScale.y, 0f));

        // The moving cube is spawned on one of its waypoints
        Vector3 spawnPos = dataContainer.movingCubeDestination[0];

        topCubeMover.increaseSpeed();

        // Spawn moving cube
        dataContainer.currentMovingCube = cubeSpawner.spawnMovingCube(spawnPos, dataContainer.currentBottomCube.transform.localScale);

        // Change color
        colorManager.changeMaterial();
        dataContainer.currentMovingCube.GetComponent<MeshRenderer>().material = colorManager.currentMaterial;

        

        // Raise camera

        Vector3 camDestination = dataContainer.currentBottomCube.transform.position + dataContainer.distCamBottomCube;


        // If the camera is still moving while the player stacked a new cube, 
        // we stop the current coroutine before starting a new one
        if (dataContainer.moveCamCoroutine != null)
            StopCoroutine(dataContainer.moveCamCoroutine);

        dataContainer.moveCamCoroutine = cameraManager.moveCamera(dataContainer.cam, camDestination, 0.75f);

        StartCoroutine(dataContainer.moveCamCoroutine);
    }

    public override Sequence chooseNextSequence()
    {
        // Move cube and listen to input
        return sequences[0];
    }

    public override void setUp()
    {
        //
    }

}
