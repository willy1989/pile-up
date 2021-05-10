using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_spawnStackedCutCubes : Sequence
{
    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ColorManager colormanager;

    [SerializeField] AudioManager audioManager;
   

    public override void SetUp()
    {
      
    }

    public override void DoAction()
    {
        GameObject[] cubes = cubeSpawner.chooseSpawningMethod(DataContainer.currentMovingCube, DataContainer.currentBottomCube);

        GameObject stackedCube = cubes[0];
        GameObject cutCube = cubes[1];

        DataContainer.currentBottomCube = stackedCube;

        stackedCube.GetComponent<MeshRenderer>().material = colormanager.CurrentMaterial;
        cutCube.GetComponent<MeshRenderer>().material = colormanager.CurrentMaterial;


        // Reset combo manager
        // Since the player didn't stack the current stacked cube perfectly, we reset the combo count
        DataContainer.comboCount = 0;

        // Play stack sound effect
        audioManager.PlaySoundEffect(audioManager.StackSound);
    }

    public override Sequence ChooseNextSequence()
    {
        // Spawn moving cube, the game loop restarts
        return Sequences[0];
    }


    // Next sequences
    // 0 
    // Spawn moving cube, the game loop restarts

}
