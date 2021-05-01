using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : MonoBehaviour
{
    public IEnumerator ienumerator;

    public IEnumerator testCoroutine()
    {
        yield return new WaitForSeconds(1f);
    }

    public void Start()
    {
        ienumerator = testCoroutine();

        StartCoroutine(ienumerator);
    }

    public void Update()
    {
        Debug.Log("ienumerator == null =" +ienumerator == null);
    }


}
