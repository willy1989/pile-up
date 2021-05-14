using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("Cube prefabs")]
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject cutCubePrefab;

    [Header("Cut cubes pool")]
    [SerializeField] int cutCubePoolIndex = -1;
    [SerializeField] GameObject[] cutCubePool;

    public void Awake()
    {
        populateCutCubePool(5);
    }

    // We only spawn the cut cubes once, and reuse it every time a new cube is stacked. It acts as an animation.
    private void populateCutCubePool(int cutCubeNumber)
    {
        cutCubePool = new GameObject[cutCubeNumber];

        for (int i = 0; i < cutCubeNumber; i++)
        {
            cutCubePool[i] = (GameObject)Instantiate(cutCubePrefab, new Vector3(10, 10, 10), Quaternion.identity);
            cutCubePool[i].SetActive(false);
        }
    }
    
    // Cycle through the pool to get the next cube
    private void incrementCutCubeIndex()
    {
        cutCubePoolIndex++;
       
        cutCubePoolIndex = cutCubePoolIndex % cutCubePool.Length;
    }

    // Based on the position of the top and bottom cubes, choose a different spawning method
    public GameObject[] SpawnStackAndCutCubes()
    {
        GameObject topCube = DataContainer.Instance.MovingCube;
        GameObject bottomCube = DataContainer.Instance.CurrentBottomCube;

        GameObject[] cubes = new GameObject[2];

        Vector3[] TCData = topCube.GetComponent<CubeCornerPosition>().GetCornerPos();
        Vector3[] BCData = bottomCube.GetComponent<CubeCornerPosition>().GetCornerPos();

        if (TCData[0].z == BCData[0].z)
        {
            // Top cube to the right
            if (TCData[0].x > BCData[0].x)
            {
                cubes = instantiateNewCubesX(topCube, TCData, BCData, 0, 5, 1);
            }

            // Top cube to the left
            else if (TCData[0].x < BCData[0].x)
            {
                cubes = instantiateNewCubesX(topCube, TCData, BCData, 1, 4, -1);
            }
        }

        else if (TCData[0].x == BCData[0].x)
        {
            // Top cube to the right
            if (TCData[0].z > BCData[0].z)
            {
                cubes = instantiateNewCubesZ(topCube, TCData, BCData, 1, 6, 1);
            }

            // Top cube to the left
            else if (TCData[0].z < BCData[0].z)
            {
                cubes = instantiateNewCubesZ(topCube, TCData, BCData, 2, 5, -1);
            }
        }

        return cubes;
    }

    public GameObject spawnCutCube(Vector3 cutCubePos)
    {
        incrementCutCubeIndex();
        GameObject cutCube = cutCubePool[cutCubePoolIndex];
        cutCube.SetActive(true);
        cutCube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cutCube.transform.position = cutCubePos;

        return cutCube;
    }

    public GameObject spawnStackedCube(Vector3 stackedCubePos)
    {
        GameObject stackedCube = (GameObject)Instantiate(cubePrefab, stackedCubePos, Quaternion.identity);
        return stackedCube;
    }


    // Calculate the width, position and scale of the new cut and stacked cubes, when the top cube moves on the Z axis
    private GameObject[] instantiateNewCubesZ(GameObject topCube, Vector3[] TCData, Vector3[] BCData, int TCCOrnerA, int TCCOrnerB, int direction)
    {
        float stackedCubeWidth = Mathf.Abs(TCData[TCCOrnerA].z - BCData[TCCOrnerB].z);

        // Coord
        float cutCubeWidth = topCube.transform.localScale.z - stackedCubeWidth;

        // Cube positions
        Vector3 stackedCubePos = BCData[TCCOrnerB] + new Vector3(-topCube.transform.localScale.x / 2, topCube.transform.localScale.y / 2, -direction * stackedCubeWidth / 2);
        Vector3 cutCubePos = BCData[TCCOrnerB] + new Vector3(-topCube.transform.localScale.x / 2, topCube.transform.localScale.y / 2, direction * cutCubeWidth / 2);

        // Spawn new cubes
        //spawnStackedCutCubes(stackedCubePos, cutCubePos);
        GameObject stackedCube = spawnStackedCube(stackedCubePos);
        GameObject cutCube = spawnCutCube(cutCubePos);

        // Change scales of new cubes
        stackedCube.transform.localScale = new Vector3(topCube.transform.localScale.x, topCube.transform.localScale.y, stackedCubeWidth);
        cutCubePool[cutCubePoolIndex].transform.localScale = new Vector3(topCube.transform.localScale.x, topCube.transform.localScale.y, cutCubeWidth);
        cutCubePool[cutCubePoolIndex].transform.rotation = Quaternion.identity;
        return new GameObject[] { stackedCube, cutCube };
    }

    // Calculate the width, position and scale of the new cut and stacked cubes, when the top cube moves on the X axis
    private GameObject[] instantiateNewCubesX(GameObject topCube, Vector3[] TCData, Vector3[]BCData, int TCCOrnerA, int TCCOrnerB, int direction)
    {
        // Stacked cube
        float stackedCubeWidth = Mathf.Abs(TCData[TCCOrnerA].x - BCData[TCCOrnerB].x);

        // Cut cube
        float cutCubeWidth = topCube.transform.localScale.x - stackedCubeWidth;

        // Cube positions
        Vector3 stackedCubePos = BCData[TCCOrnerB] + new Vector3(-direction * stackedCubeWidth / 2, topCube.transform.localScale.y / 2, topCube.transform.localScale.z / 2);
        Vector3 cutCubePos = BCData[TCCOrnerB] + new Vector3(direction * cutCubeWidth / 2, topCube.transform.localScale.y / 2, topCube.transform.localScale.z / 2);

        // Spawn new cubes
        //spawnStackedCutCubes(stackedCubePos, cutCubePos);
        GameObject stackedCube = spawnStackedCube(stackedCubePos);
        GameObject cutCube = spawnCutCube(cutCubePos);

        // Change scales of new cubes
        stackedCube.transform.localScale = new Vector3(stackedCubeWidth, topCube.transform.localScale.y, topCube.transform.localScale.z);
        cutCubePool[cutCubePoolIndex].transform.localScale = new Vector3(cutCubeWidth, topCube.transform.localScale.y, topCube.transform.localScale.z);
        cutCubePool[cutCubePoolIndex].transform.rotation = Quaternion.identity;
        return new GameObject[] { stackedCube, cutCube };
    }


    // Spawn a new cube above of the bottom cube
    // It moves back and forth until the player decides to place it on the stack
    // Its scale should be the same as the current bottom cube
    public void SpawnMovingCube()
    {
        DataContainer.Instance.MovingCube.SetActive(true);

        DataContainer.Instance.MovingCube.transform.localScale = DataContainer.Instance.CurrentBottomCube.transform.localScale;

        DataContainer.Instance.MovingCube.transform.position = DataContainer.Instance.MovingCubeDestination[0];

        DataContainer.Instance.MovingCube.transform.rotation = Quaternion.identity;
    }


    public void SetRigidBdtoGravity(GameObject go)
    {
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void SetCubeScale(GameObject cubeToChange, Vector3 newScale)
    {
        cubeToChange.transform.localScale = newScale;
    }

}
