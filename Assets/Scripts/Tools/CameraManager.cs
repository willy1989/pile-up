using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private IEnumerator moveCamCoroutine;

    [SerializeField] Camera cam;

    public void MoveCamera(Vector3 destination, float lerpDuration)
    {
        // If the camera is still moving while the player stacked a new cube, 
        // we stop the current coroutine before starting a new one
        if (moveCamCoroutine != null)
        {
            StopCoroutine(moveCamCoroutine);
        }

        moveCamCoroutine = moveCameraCoroutine(destination, lerpDuration);

        StartCoroutine(moveCamCoroutine);
    }

    // We move the oject until we reach the destination
    private IEnumerator moveCameraCoroutine(Vector3 destination, float lerpDuration)
    {
        Vector3 startPos = cam.transform.position;

        float lerpTime = 0f;

        float t = 0f;

        // Ease out
        while (lerpDuration > lerpTime)
        {
            t = lerpTime / lerpDuration;

            t = Mathf.Pow(t - 1, 3) + 1;

            Vector3 newPos = Vector3.Lerp(startPos, destination, t);

            cam.transform.position = newPos;

            lerpTime += Time.deltaTime;

            yield return null;
        }
    }
}
