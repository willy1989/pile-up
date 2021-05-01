using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_checkStackCubeCollision : Sequence
{
    [SerializeField] CubeCollision cubeCollision;

    public override void doAction()
    {
        //Debug.Log("Top and bottom cube are perfectly aligned = " + cubeCollision.checkCubesPerfectlyAligned(dataContainer.currentMovingCube.GetComponent<CubeCornerPosition>(), dataContainer.currentBottomCube.GetComponent<CubeCornerPosition>()));
    }

    public override void setUp()
    {

    }

    public override Sequence chooseNextSequence()
    {
        bool touchBottomCube = cubeCollision.checkCubeCollision(dataContainer.currentMovingCube.transform.position, dataContainer.currentBottomCube.transform.localScale);

        bool cubesPerfectlyAligned = cubeCollision.checkCubesPerfectlyAligned(dataContainer.currentMovingCube.GetComponent<CubeCornerPosition>(), dataContainer.currentBottomCube.GetComponent<CubeCornerPosition>(),new Vector2(dataContainer.currentDestination.x, dataContainer.currentDestination.z));

        if (cubesPerfectlyAligned == true)
        {
            // Only spawn stacked cube
            return sequences[2];
        }

        else if(touchBottomCube == true)
        {
            // Spawn cut and stacked cubes
            return sequences[1];
        }

        else
        {
            // Game over 
            return sequences[0];
        }
    }
}
