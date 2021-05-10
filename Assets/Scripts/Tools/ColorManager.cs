using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // We attribute each block a color when spawning it
    // Each color group is fade of 7 colors (dark blue to light blue for instance)
    // We pick a random group, different from the last, and iterate through each of its 7 shades
    // Once we went through the seven shades we pick a new random group and the cycle continues

    [SerializeField] Material[] materials;

    private int index = -1;

    private int groupIndex;

    public Material CurrentMaterial;

    public void ChangeMaterial()
    {
        // Get next index, it always goes from 1 to 6
        index++;

        index = index % 7;

        // When a new cycle starts, get a new random group of materials
        if (index == 0)
        {
            int randNum = Random.Range(0, materials.Length / 7);

            // Iterate until the new current group index is different from the current one
            while (randNum == groupIndex)
            {
                randNum = Random.Range(0, materials.Length / 7);
            }

            groupIndex = randNum;
        }

        // Based on the current index and the current group set the current material 

        CurrentMaterial = materials[groupIndex * 7 + index];
    }





    


}
