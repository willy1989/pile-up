using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrower : MonoBehaviour
{
    private bool _coroutineRunning = false;

    public bool CoroutineRunning
    {
        get
        {
            return _coroutineRunning;
        }

        private set
        {
            _coroutineRunning = value;
        }
    }

    public void growCube (Vector3 scaleToAdd, GameObject goToScale)
    {
        goToScale.transform.position -= scaleToAdd / 2;
        goToScale.transform.localScale += scaleToAdd;
    }

    public IEnumerator growCubeCoroutine(Vector3 scaleToAdd, GameObject goToScale, float duration)
    {
        CoroutineRunning = true;

        float elapsedTime = 0f;

        Vector3 finalScale = goToScale.transform.localScale + scaleToAdd;

        Vector3 finalPos = goToScale.transform.position - scaleToAdd / 2;

        Vector3 startScale = goToScale.transform.localScale;

        Vector3 startPos = goToScale.transform.position;

        while (elapsedTime / duration  < 1f)
        {
            goToScale.transform.position = Vector3.Lerp(startPos, finalPos, elapsedTime / duration);

            goToScale.transform.localScale = Vector3.Lerp(startScale, finalScale, elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        CoroutineRunning = false;
    }
}
