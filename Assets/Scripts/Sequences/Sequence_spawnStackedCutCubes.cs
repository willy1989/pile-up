using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_spawnStackedCutCubes : Sequence
{
    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ColorManager colormanager;
   

    public override void setUp()
    {
      
    }

    public override void doAction()
    {
        GameObject[] cubes = cubeSpawner.chooseSpawningMethod(dataContainer.currentMovingCube, dataContainer.currentBottomCube);

        GameObject stackedCube = cubes[0];
        GameObject cutCube = cubes[1];

        dataContainer.currentBottomCube = stackedCube;

        stackedCube.GetComponent<MeshRenderer>().material = colormanager.currentMaterial;
        cutCube.GetComponent<MeshRenderer>().material = colormanager.currentMaterial;


        // Reset combo manager
        // Since the player didn't stack the current stacked cube perfectly, we reset the combo count
        dataContainer.comboCount = 0;
    }

    public override Sequence chooseNextSequence()
    {
        // Spawn moving cube, the game loop restarts
        return sequences[0];
    }


    // Next sequences
    // 0 
    // Spawn moving cube, the game loop restarts

}
