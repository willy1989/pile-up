using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    public static DataContainer Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject CurrentBottomCube;

    public GameObject MovingCube;

    public Vector3[] MovingCubeDestination;

    public Vector3 CurrentDestination;

    public Transform Cam;

    public int ComboCount = 0;
}


