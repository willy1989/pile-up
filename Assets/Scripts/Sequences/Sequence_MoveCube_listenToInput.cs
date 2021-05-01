using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_MoveCube_listenToInput : Sequence
{
    [SerializeField] InputManager inputManager;

    [SerializeField] TopCubeMover topCubeMover;

    private bool touchDown = false;


    public override void setUp()
    {
        touchDown = false;

        
        
        dataContainer.currentDestination = topCubeMover.changeDestination(dataContainer.movingCubeDestination[0]);
    }


    public override void doAction()
    {
        checkInput();
        moveCube();
    }

    // Check each frame whether the player touched the screen down
    public void checkInput()
    {
        if(inputManager.touchDown() == true)
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
        if(topCubeMover.checkIfReachedDestination(dataContainer.currentMovingCube, dataContainer.movingCubeDestination[0]) == true)
        {
            dataContainer.currentDestination = topCubeMover.changeDestination(dataContainer.movingCubeDestination[1]);
        }

        else if(topCubeMover.checkIfReachedDestination(dataContainer.currentMovingCube, dataContainer.movingCubeDestination[1]) == true)
        {
            dataContainer.currentDestination = topCubeMover.changeDestination(dataContainer.movingCubeDestination[0]);
        }

        topCubeMover.moveCubeTo(dataContainer.currentMovingCube, dataContainer.currentDestination);
    }


    public override Sequence chooseNextSequence()
    {
        if(touchDown == false)
        {
            // This sequence
            return sequences[0];
        }

        else
        {
            // Check cube collision
            return sequences[1];
        }
    }

    
}
