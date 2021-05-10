using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_checkStackCubeCollision : Sequence
{
    [SerializeField] CubeCollision cubeCollision;

    public override void DoAction()
    {
        //Debug.Log("Top and bottom cube are perfectly aligned = " + cubeCollision.checkCubesPerfectlyAligned(dataContainer.currentMovingCube.GetComponent<CubeCornerPosition>(), dataContainer.currentBottomCube.GetComponent<CubeCornerPosition>()));
    }

    public override void SetUp()
    {

    }

    public override Sequence ChooseNextSequence()
    {
        bool touchBottomCube = cubeCollision.CheckCubeCollision(DataContainer.currentMovingCube.transform.position, DataContainer.currentBottomCube.transform.localScale);

        bool cubesPerfectlyAligned = cubeCollision.CheckCubesPerfectlyAligned(DataContainer.currentMovingCube.GetComponent<CubeCornerPosition>(), DataContainer.currentBottomCube.GetComponent<CubeCornerPosition>(),new Vector2(DataContainer.currentDestination.x, DataContainer.currentDestination.z));

        if (cubesPerfectlyAligned == true)
        {
            // Only spawn stacked cube
            return Sequences[2];
        }

        else if(touchBottomCube == true)
        {
            // Spawn cut and stacked cubes
            return Sequences[1];
        }

        else
        {
            // Game over 
            return Sequences[0];
        }
    }
}
