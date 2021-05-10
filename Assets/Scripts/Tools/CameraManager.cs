using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // We move the oject until we reach the destination
    public IEnumerator MoveCamera(Transform objectToMove,Vector3 destination, float lerpDuration)
    {
        Vector3 startPos = objectToMove.transform.position;

        float lerpTime = 0f;

        float t = 0f;

        // Ease in, ease out
        /*while (lerpDuration > lerpTime)
        {
            t = lerpTime / lerpDuration;

            t = t * t * (3f - 2f * t);

            Vector3 newPos = Vector3.Lerp(startPos, destination, t);

            objectToMove.position = newPos;

            lerpTime += Time.deltaTime;

            yield return null;
        }
        */

        // Linear movement
        /*while (lerpDuration > lerpTime)
        {
            t = lerpTime / lerpDuration;

            Vector3 newPos = Vector3.Lerp(startPos, destination, t);

            objectToMove.position = newPos;

            lerpTime += Time.deltaTime;

            yield return null;
        }
        */

        // Ease out
        while (lerpDuration > lerpTime)
        {
            t = lerpTime / lerpDuration;

            t = Mathf.Pow(t - 1, 3) + 1;

            Vector3 newPos = Vector3.Lerp(startPos, destination, t);

            objectToMove.position = newPos;

            lerpTime += Time.deltaTime;

            yield return null;
        }
    }
}
