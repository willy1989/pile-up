using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCornerPosition : MonoBehaviour
{
    
    public Vector3[] getCornerPos()
    {
        Vector3[] corners = new Vector3[8];

        float X = transform.lossyScale.x/2;
        float Y = transform.lossyScale.y/2;
        float Z = transform.lossyScale.z/2;

        corners[0] = transform.position + new Vector3(-X, -Y, -Z);
        corners[1] = transform.position + new Vector3(X, -Y, -Z);
        corners[2] = transform.position + new Vector3(X, -Y, Z);
        corners[3] = transform.position + new Vector3(-X, -Y, Z);
        corners[4] = transform.position + new Vector3(-X, Y, -Z);
        corners[5] = transform.position + new Vector3(X, Y, -Z);
        corners[6] = transform.position + new Vector3(X, Y, Z);
        corners[7] = transform.position + new Vector3(-X, Y, Z);

        return corners;
    }



    // Bottom    Top
    // 3  2      7  6
    // 0  1      4  5


    // 0  -x, -y, -z
    // 1  x, -y, -z
    // 2  x, -y, z
    // 3  -x, -y, z
    // 4  -x, y, -z
    // 5  x, y, -z
    // 6  x, y, z
    // 7  -x, y, z


}
