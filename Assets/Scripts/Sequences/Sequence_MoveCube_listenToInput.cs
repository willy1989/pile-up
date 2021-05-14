using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_MoveCube_listenToInput : Sequence
{
    [SerializeField] InputManager inputManager;

    [SerializeField] TopCubeMover topCubeMover;

    private bool touchDown = false;


    public override void SetUp()
    {
        touchDown = false;

        DataContainer.Instance.CurrentDestination = DataContainer.Instance.MovingCubeDestination[0];
    }

    public override void DoAction()
    {
        // Check input
        // Check each frame whether the player touched the screen down

        if (inputManager.TouchDown() == true)
        {
            touchDown = true;
        }

        // Move top cube
        // If the player taps the screen, then we stop moving the cube right away, i.e. the frame when the player tapped the screen
        if (touchDown == false)
        {
            topCubeMover.MoveTopCube();
        }
    }

    public override Sequence ChooseNextSequence()
    {
        if(touchDown == false)
        {
            // This sequence
            return Sequences[0];
        }

        else
        {
            // Check cube collision
            return Sequences[1];
        }
    }

    
}
