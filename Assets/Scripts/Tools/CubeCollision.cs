using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public bool checkCubeCollision(Vector3 overlapBoxPos, Vector3 overlapBoxScale)
    {
        Collider[] colliders = Physics.OverlapBox(overlapBoxPos, overlapBoxScale / 2);

        //Debug.Log("colliders.Length =" + colliders.Length);
        foreach(Collider col in colliders)
        {
            //Debug.Log("collider =" + col.name);
        }

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
    public bool checkCubesPerfectlyAligned(CubeCornerPosition topCubeData, CubeCornerPosition bottomCubeData, Vector2 currentWayPoint)
    {
        Vector2 topCubeCornerPos = new Vector2(topCubeData.getCornerPos()[0].x, topCubeData.getCornerPos()[0].z);
        Vector2 bottomCubeCornerPos = new Vector2(bottomCubeData.getCornerPos()[0].x, bottomCubeData.getCornerPos()[0].z);

        float dist = (topCubeCornerPos - bottomCubeCornerPos).magnitude;

        

        if (dist < 0.07f)
        {
            //Debug.Log("currentWayPoint = " + currentWayPoint);

            float distTopCubeWayPoint = (topCubeCornerPos - currentWayPoint).magnitude;
            float distBottomCubeWayPoint = (bottomCubeCornerPos - currentWayPoint).magnitude;

            //Debug.Log("distTopCubeWayPoint = " + distTopCubeWayPoint);
            //Debug.Log("distBottomCubeWayPoint = " + distBottomCubeWayPoint);

            if (topCubeCornerPos.y > bottomCubeCornerPos.y && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                Debug.Log("X axis");
                return true;
            }
            

            else if(topCubeCornerPos.y < bottomCubeCornerPos.y && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                return true;
            }

            else if (topCubeCornerPos.x > bottomCubeCornerPos.x && distTopCubeWayPoint > distBottomCubeWayPoint)
            {
                Debug.Log("X axis");
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
