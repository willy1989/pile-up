using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrower : MonoBehaviour
{
    public bool coroutineRunning = false;

    public void growCube (Vector3 scaleToAdd, GameObject goToScale)
    {
        goToScale.transform.position -= scaleToAdd / 2;
        goToScale.transform.localScale += scaleToAdd;
    }

    public IEnumerator growCubeCoroutine(Vector3 scaleToAdd, GameObject goToScale, float duration)
    {
        coroutineRunning = true;

        float elapsedTime = 0f;

        Vector3 finalScale = goToScale.transform.localScale + scaleToAdd;

        Vector3 finalPos = goToScale.transform.position - scaleToAdd / 2;

        Vector3 startScale = goToScale.transform.localScale;

        Vector3 startPos = goToScale.transform.position;

        while (elapsedTime / duration  < 1f)
        {
            //Debug.Log("growCubeCoroutine running");

            //Debug.Log("elapsedTime / duration =" + elapsedTime / duration);

            goToScale.transform.position = Vector3.Lerp(startPos, finalPos, elapsedTime / duration);

            goToScale.transform.localScale = Vector3.Lerp(startScale, finalScale, elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        coroutineRunning = false;
    }
}
