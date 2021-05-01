using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePlayer : MonoBehaviour
{
    [SerializeField] Sequence currentSequence;


    private void Update()
    {
        playSequence();
        getNextSequence();
    }


    private void playSequence()
    {
        currentSequence.doAction();
    }

    // When the player changes sequence, the new sequence's setup() method is called
    private void getNextSequence()
    {
        Sequence newSequence = currentSequence.chooseNextSequence();

        // Playing new sequence
        if(currentSequence != newSequence)
        {
            //Debug.Log("Sequence : " + newSequence.name);
            currentSequence = newSequence;
            currentSequence.setUp();
        }
    }
}
