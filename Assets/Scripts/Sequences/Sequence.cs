using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sequence : MonoBehaviour
{
    public DataContainer dataContainer;

    public Sequence[] sequences;

    public abstract void doAction();

    public abstract Sequence chooseNextSequence();

    // Called everytime the current sequence changes
    public abstract void setUp();
}
