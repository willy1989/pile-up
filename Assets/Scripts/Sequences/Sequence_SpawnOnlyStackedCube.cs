using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_SpawnOnlyStackedCube : Sequence
{
    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ColorManager colorManager;

    [SerializeField] ParticleSystemManager particleSystemManager;

    [SerializeField] AudioManager audioManager;

    public override void setUp()
    {
       
    }

    private void spawnCube()
    {
        // Spawn stacked cube

        // Same position as the current bottom cube + 1 Y unit above,
        // So that the stacked cube is perfecly aligned with the bottom cube
        Vector3 spawnPos = dataContainer.currentBottomCube.transform.position + new Vector3(0f, dataContainer.currentBottomCube.transform.localScale.y, 0f);
        GameObject stackedCube = cubeSpawner.spawnStackedCube(spawnPos);

        stackedCube.GetComponent<MeshRenderer>().material = colorManager.currentMaterial;

        // Scale stacked cube
        cubeSpawner.setCubeScale(stackedCube, dataContainer.currentBottomCube.transform.localScale);

        // Update combo count
        // Only grow the stacked cube when the player stacked 5 cubes perfectly in a row
        dataContainer.comboCount++;

        // Particle system effect
        particleSystemManager.playStackParticleEffect(stackedCube, dataContainer.comboCount);


        // Update references
        dataContainer.currentBottomCube = stackedCube;

        GameObject.Destroy(dataContainer.currentMovingCube);

        dataContainer.currentMovingCube = null;
    }

    private bool checkGrowCube()
    {
        if (dataContainer.comboCount >= 5)
        {
            dataContainer.comboCount = 0;
            return true;
        }

        else
        {
            return false;
        }
    }

    public override void doAction()
    {
        spawnCube();
        // Play stack sound effect
        audioManager.playSoundEffect(audioManager.perfectlyStackSound);
    }

    public override Sequence chooseNextSequence()
    {
        // Grow cube
        if (checkGrowCube() == true)
        {
            return sequences[0];
        }
            

        // Spawn moving cube, the game loop restarts
        else
        {
            return sequences[1];
        }
            
        
    }

}
