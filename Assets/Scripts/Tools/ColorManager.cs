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

    public Material currentMaterial;

    public void changeMaterial()
    {
        currentMaterial = getNextMaterial();
    }

    public Material getNextMaterial()
    {
        getNextIndex();

        if(index == 0)
        {
            getRandomGroupIndex();
        }

        return materials[groupIndex*7 + index];
    }

    public void getNextIndex()
    {
        index++;

        index = index % 7;
    }

    public void getRandomGroupIndex()
    {
        int randNum = Random.Range(0, materials.Length/7);

        //Debug.Log("randNum =" + randNum);

        // Iterate until the new current group index is different from the current one
        while (randNum == groupIndex)
        {
            randNum = Random.Range(0, materials.Length / 7);
        }

        groupIndex = randNum;
    }


    


}
