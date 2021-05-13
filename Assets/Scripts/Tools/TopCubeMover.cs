using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCubeMover : MonoBehaviour
{
    private bool leftAxis = false;

    private float speed = 1.75f;

    // Moves the moving between two waypoints
    // Sets those 2 waypoints


    // Randomly choose 2 points place either on the x or z axis
    public void UpdateDataContainerMovingCubeDestination()
    {
        Vector3 centerPos = DataContainer.Instance.CurrentBottomCube.transform.position + new Vector3(0f, DataContainer.Instance.CurrentBottomCube.transform.lossyScale.y, 0f);

        Vector3[] destinations = new Vector3[2];

        if(leftAxis == true)
        {
            destinations[0] = centerPos + new Vector3(2, 0, 0);
            destinations[1] = centerPos + new Vector3(-2, 0, 0);
        }

        else
        {
            destinations[0] = centerPos + new Vector3(0, 0, 2);
            destinations[1] = centerPos + new Vector3(0, 0, -2);
        }

        leftAxis = !leftAxis;

        DataContainer.Instance.MovingCubeDestination = destinations;
    }

    public void MoveTopCube()
    {
        // Every time the moving cube reaches one of its 2 destination, the next destination becomes the other one
        if (CheckIfReachedDestination(DataContainer.Instance.CurrentMovingCube, DataContainer.Instance.MovingCubeDestination[0]) == true)
        {
            DataContainer.Instance.CurrentDestination = DataContainer.Instance.MovingCubeDestination[1];
        }

        else if (CheckIfReachedDestination(DataContainer.Instance.CurrentMovingCube, DataContainer.Instance.MovingCubeDestination[1]) == true)
        {
            DataContainer.Instance.CurrentDestination = DataContainer.Instance.MovingCubeDestination[0];
        }

        Vector3 destination = DataContainer.Instance.CurrentDestination;

        GameObject movingCube = DataContainer.Instance.CurrentMovingCube;

        Vector3 direction = (destination - movingCube.transform.position).normalized;

        Vector3 moveVec = direction * speed * Time.deltaTime;
        movingCube.transform.position += moveVec;
    }

    public bool CheckIfReachedDestination(GameObject movingCube, Vector3 destination)
    {
        if((destination - movingCube.transform.position).magnitude < 0.1f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void IncreaseSpeed()
    {
        speed += 0.01f;
    }
}
