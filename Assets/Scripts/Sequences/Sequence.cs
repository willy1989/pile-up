using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sequence : MonoBehaviour
{
    public Sequence[] Sequences;

    public abstract void DoAction();

    public abstract Sequence ChooseNextSequence();

    // Called everytime the current sequence changes
    public abstract void SetUp();
}
