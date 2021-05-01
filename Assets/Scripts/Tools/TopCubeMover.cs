using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCubeMover : MonoBehaviour
{
    private bool leftAxis = false;

    public float speed = 1f;

    // Moves the moving between two waypoints
    // Sets those 2 waypoints


    // Randomly choose 2 points place either on the x or z axis
    public Vector3[] getDestinations(Vector3 centerPos)
    {
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

        return destinations;
    }

    public void moveCubeTo(GameObject movingCube, Vector3 destination)
    {
        Vector3 direction = (destination - movingCube.transform.position).normalized;

        Vector3 moveVec = direction * speed * Time.deltaTime;
        movingCube.transform.position += moveVec;
    }

    public Vector3 changeDestination(Vector3 newDestination)
    {
        return newDestination;
    }

    public bool checkIfReachedDestination(GameObject movingCube, Vector3 destination)
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

    public void increaseSpeed()
    {
        speed += 0.01f;
    }
}
