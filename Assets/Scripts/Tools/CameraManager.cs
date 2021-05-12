using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private IEnumerator moveCamCoroutine;

    [SerializeField] Camera cam;

    // When moving the camera. We add this distance to the destination to maintain the same distance of the current bottom cube from the camera
    // We assume the first bottom cube is always at the origin (0,0,0)
    private Vector3 distCamBottomCube; 

    private void Awake()
    {
        distCamBottomCube = cam.transform.position;
    }

    public void MoveCamera()
    {
        // If the camera is still moving while the player stacked a new cube, 
        // we stop the current coroutine before starting a new one
        if (moveCamCoroutine != null)
        {
            StopCoroutine(moveCamCoroutine);
        }

        moveCamCoroutine = moveCameraCoroutine();

        StartCoroutine(moveCamCoroutine);
    }

    // We move the oject until we reach the destination
    private IEnumerator moveCameraCoroutine()
    {
        Vector3 startPos = cam.transform.position;

        Vector3 destination = DataContainer.Instance.CurrentBottomCube.transform.position + distCamBottomCube;

        float lerpDuration = 0.75f;

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
