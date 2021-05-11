using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_SpawnOnlyStackedCube : Sequence
{
    [SerializeField] CubeSpawner cubeSpawner;

    [SerializeField] ColorManager colorManager;

    [SerializeField] ParticleSystemManager particleSystemManager;

    [SerializeField] AudioManager audioManager;

    public override void SetUp()
    {
       
    }

    private void spawnCube()
    {
        // Spawn stacked cube

        // Same position as the current bottom cube + 1 Y unit above,
        // So that the stacked cube is perfecly aligned with the bottom cube
        Vector3 spawnPos = DataContainer.CurrentBottomCube.transform.position + new Vector3(0f, DataContainer.CurrentBottomCube.transform.localScale.y, 0f);
        GameObject stackedCube = cubeSpawner.spawnStackedCube(spawnPos);

        stackedCube.GetComponent<MeshRenderer>().material = colorManager.CurrentMaterial;

        // Scale stacked cube
        cubeSpawner.SetCubeScale(stackedCube, DataContainer.CurrentBottomCube.transform.localScale);

        // Update combo count
        // Only grow the stacked cube when the player stacked 5 cubes perfectly in a row
        DataContainer.ComboCount++;

        // Particle system effect
        particleSystemManager.PlayStackParticleEffect(stackedCube, DataContainer.ComboCount);


        // Update references
        DataContainer.CurrentBottomCube = stackedCube;

        GameObject.Destroy(DataContainer.CurrentMovingCube);

        DataContainer.CurrentMovingCube = null;
    }

    private bool checkGrowCube()
    {
        if (DataContainer.ComboCount >= 5)
        {
            DataContainer.ComboCount = 0;
            return true;
        }

        else
        {
            return false;
        }
    }

    public override void DoAction()
    {
        spawnCube();
        // Play stack sound effect
        audioManager.PlaySoundEffect(audioManager.PerfectlyStackSound);
    }

    public override Sequence ChooseNextSequence()
    {
        // Grow cube
        if (checkGrowCube() == true)
        {
            return Sequences[0];
        }
            

        // Spawn moving cube, the game loop restarts
        else
        {
            return Sequences[1];
        }
            
        
    }

}
