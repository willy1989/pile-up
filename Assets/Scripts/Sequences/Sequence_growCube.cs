using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_growCube : Sequence
{
    [SerializeField] CubeGrower cubeGrower;

    [SerializeField] AudioManager audioManager;


    public override void SetUp()
    {
        audioManager.PlaySoundEffect(audioManager.GrowCubeSound);
        growCube();
    }

    public override void DoAction()
    {
        
            
    }

    private void growCube()
    {

        // Grow stacked cube
        Vector3 newScale = Vector3.zero;

        if (DataContainer.movingCubeDestination[0].x > DataContainer.movingCubeDestination[0].z)
        {
            newScale = new Vector3(0.05f, 0f, 0f);
        }

        else
        {
            newScale = new Vector3(0f, 0f, 0.05f);
        }

        StartCoroutine(cubeGrower.growCubeCoroutine(newScale, DataContainer.currentBottomCube, 0.5f));
    }

    public override Sequence ChooseNextSequence()
    {
        if(cubeGrower.CoroutineRunning == true)
        {
            // Keep playing current sequence while the cube is still growing
            return Sequences[0];
        }

        else
        {
            // Spawn moving cube
            return Sequences[1];
        }
    }
}
