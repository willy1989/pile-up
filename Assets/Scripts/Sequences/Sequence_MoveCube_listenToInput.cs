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

        
        
        DataContainer.CurrentDestination = topCubeMover.ChangeDestination(DataContainer.MovingCubeDestination[0]);
    }


    public override void DoAction()
    {
        checkInput();
        moveCube();
    }

    // Check each frame whether the player touched the screen down
    public void checkInput()
    {
        if(inputManager.TouchDown() == true)
        {
            touchDown = true;
        }

        // If the player taps the screen, then we stop moving the cube right away, i.e. the frame when the player tapped the screen
        if(touchDown == false)
        {
            moveCube();
        }
        
    }

    public void moveCube()
    {
        // Every time the moving cube reaches one of its 2 destination, the next destination becomes the other one
        if(topCubeMover.CheckIfReachedDestination(DataContainer.CurrentMovingCube, DataContainer.MovingCubeDestination[0]) == true)
        {
            DataContainer.CurrentDestination = topCubeMover.ChangeDestination(DataContainer.MovingCubeDestination[1]);
        }

        else if(topCubeMover.CheckIfReachedDestination(DataContainer.CurrentMovingCube, DataContainer.MovingCubeDestination[1]) == true)
        {
            DataContainer.CurrentDestination = topCubeMover.ChangeDestination(DataContainer.MovingCubeDestination[0]);
        }

        topCubeMover.MoveCubeTo(DataContainer.CurrentMovingCube, DataContainer.CurrentDestination);
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
