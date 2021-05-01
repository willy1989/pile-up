using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTest : MonoBehaviour
{
    public Material material;

    public Color colorStart;

    public Color colorEnd;

    private Color currentColor;

    public void Start()
    {
        StartCoroutine(changeColor(1f));
    }

    public IEnumerator changeColor(float duration)
    {
        currentColor = colorStart;

        float t = 0f;

        while(t/duration < 1)
        {
            currentColor = Color.Lerp(colorStart, colorEnd, t / duration);

            material.SetColor("_Color", currentColor);

            
            Debug.Log(currentColor.r + "-" + currentColor.g+ "-" + currentColor.b);

            t += 0.1f;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
