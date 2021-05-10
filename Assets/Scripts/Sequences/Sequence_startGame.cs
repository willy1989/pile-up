using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_startGame : Sequence
{
    // This sequence plays at the beginning of the game before the actual game starts,
    // and after the set up sequence
    // It plays until the player taps the screen to tap the game

    [SerializeField] InputManager inputManager;

    [SerializeField] UI_manager uiManager;

    private bool touchDown = false;


    // Check each frame whether the player touched the screen down
    public void checkInput()
    {
        touchDown = inputManager.TouchDown();
    }

    public override void SetUp()
    {
        touchDown = false;
    }

    public override void DoAction()
    {
        checkInput();
        if(touchDown == true)
        {
            uiManager.showUiElement(uiManager.HighScoreText.gameObject, false);
            uiManager.showUiElement(uiManager.ScoreText.gameObject, true);
            uiManager.showUiElement(uiManager.StartGameText.gameObject, false);
        }
        
    }

    public override Sequence ChooseNextSequence()
    {
        if (touchDown == false)
        {
            // This sequence
            return Sequences[0];
        }

        else
        {
            // Spawn moving cube
            return Sequences[1];
        }
    }


}
