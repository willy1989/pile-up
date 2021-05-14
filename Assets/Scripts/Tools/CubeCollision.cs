using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public bool CheckCubeCollision(Vector3 overlapBoxPos, Vector3 overlapBoxScale)
    {
        Collider[] colliders = Physics.OverlapBox(overlapBoxPos, overlapBoxScale / 2);

        // Only one collider means the overlapbox only collided with the top cube
        // Two colliders means the overlapbox collided with the bottom and top cube, 
        // which means top cube touches bottom cube

        if(colliders.Length == 2)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    // Compare the position of the same corner of both cubes
    // to check whether they are perfectly aligned or at least very close
    public bool CheckCubesPerfectlyAligned(CubeCornerPosition topCubeData, CubeCornerPosition bottomCubeData, Vector2 currentWayPoint)
    {
        Vector2 topCubeCornerPos = new Vector2(topCubeData.GetCornerPos()[0].x, topCubeData.GetCornerPos()[0].z);
        Vector2 bottomCubeCornerPos = new Vector2(bottomCubeData.GetCornerPos()[0].x, bottomCubeData.GetCornerPos()[0].z);

        float dist = (topCubeCornerPos - bottomCubeCornerPos).magnitude;

        if (dist < 0.07f)
        {
            float distTopCubeWayPoint = (topCubeCornerPos - currentWayPoint).magnitude;
            float distBottomCubeWayPoint = (bottomCubeCornerPos - currentWayPoint).magnitude;

            if (topCubeCornerPos.y > bottomCubeCornerPos.y && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                return true;
            }

            else if(topCubeCornerPos.y < bottomCubeCornerPos.y && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                return true;
            }

            else if (topCubeCornerPos.x > bottomCubeCornerPos.x && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                return true;
            }

            else if (topCubeCornerPos.x < bottomCubeCornerPos.x && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        else
        {
            return false;
        }
    }

}
