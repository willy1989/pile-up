using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// When a cut cube is spawned, it is deactivated after a few seconds
// Cut cubes act as animations, they spawn, fall down and disappear out of the frame,

public class CutCube_deactivate : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(deactivateCoroutine());
    }

    public IEnumerator deactivateCoroutine()
    {
        yield return new WaitForSeconds(2f);

        deactivateGO();
    }

    private void deactivateGO()
    {
        this.gameObject.SetActive(false);
    }
}
