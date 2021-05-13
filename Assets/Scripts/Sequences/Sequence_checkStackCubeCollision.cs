using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_checkStackCubeCollision : Sequence
{
    [SerializeField] CubeCollision cubeCollision;

    public override void DoAction()
    {
        
    }

    public override void SetUp()
    {

    }

    public override Sequence ChooseNextSequence()
    {
        bool touchBottomCube = cubeCollision.CheckCubeCollision(DataContainer.Instance.CurrentMovingCube.transform.position, DataContainer.Instance.CurrentBottomCube.transform.localScale);

        bool cubesPerfectlyAligned = cubeCollision.CheckCubesPerfectlyAligned(DataContainer.Instance.CurrentMovingCube.GetComponent<CubeCornerPosition>(), DataContainer.Instance.CurrentBottomCube.GetComponent<CubeCornerPosition>(),new Vector2(DataContainer.Instance.CurrentDestination.x, DataContainer.Instance.CurrentDestination.z));

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
