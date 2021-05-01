using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_growCube : Sequence
{
    [SerializeField] CubeGrower cubeGrower;


    public override void setUp()
    {
        growCube();
    }

    public override void doAction()
    {
        
            
    }

    private void growCube()
    {

        // Grow stacked cube
        Vector3 newScale = Vector3.zero;

        if (dataContainer.movingCubeDestination[0].x > dataContainer.movingCubeDestination[0].z)
        {
            newScale = new Vector3(0.05f, 0f, 0f);
        }

        else
        {
            newScale = new Vector3(0f, 0f, 0.05f);
        }

        StartCoroutine(cubeGrower.growCubeCoroutine(newScale, dataContainer.currentBottomCube, 0.5f));
    }

    public override Sequence chooseNextSequence()
    {
        if(cubeGrower.coroutineRunning == true)
        {
            // Keep playing current sequence while the cube is still growing
            return sequences[0];
        }

        else
        {
            // Spawn moving cube
            return sequences[1];
        }
    }
}
