using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityTest : MonoBehaviour
{
    public Rigidbody rb;

    public Transform objectTransform;

    public Vector3 startPos;

    public void Awake()
    {
        startPos = objectTransform.position;
    }

    public void setRBVelTo0()
    {
        objectTransform.position = startPos;
        rb.velocity = Vector3.zero;
    }
}
