using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    public GameObject currentBottomCube;

    public GameObject currentMovingCube;

    //public GameObject currentTopCube;

    public Vector3[] movingCubeDestination;

    public Vector3 currentDestination;

    public Transform cam;

    public Vector3 distCamBottomCube;

    public IEnumerator moveCamCoroutine;

    public int comboCount = 0;

   
}


