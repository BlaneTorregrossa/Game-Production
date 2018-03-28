using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopBehaviour : MonoBehaviour
{
    public GameType.GameMode CurrentGameMode;   //  Current Game mode for given scene
    public CharacterBehaviour PlayerCharacter;   //  Character Behaviour for Player
    public CharacterBehaviour OpponentCharacter; //  Character Behaviour for Opponent
    public List<CharacterBehaviour> TargetCharacters;    //  List of targets in the Target Range

    private bool Paused;    //  For determining if game is paused
    [SerializeField] private int RoundMax;   //  Max amount of rounds for the match. Might need to move to the Round Scriptable Object.
    private Round CurrentRound;   //  Round Scriptable Object being used    ***
    [SerializeField] private float SetTime;  //  Starting time for round
    [SerializeField] private float RoundTime;    //  Time for each Round
    [SerializeField] private float PausedTime;   //  Time while paused
    [SerializeField] private GameObject MenuUI; //  Menu based UI that is made avalible once certain conditions are met
    [SerializeField] private GameObject CharacterChange;  //   Character objects in the scene

    void Start()
    {
        #region Target Range Start
        //  Disables Pause menu, enable characters
        if (CurrentGameMode == GameType.GameMode.TARGETRANGE)
        {
            MenuUI.SetActive(false);
            CharacterChange.SetActive(true);
        }
        #endregion

        #region PVP Start
        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            MenuUI.SetActive(false);    //  Temporary   ***
            CharacterChange.SetActive(true);    //  Temporary   ***
        }
        #endregion
    }

    void Update()
    {
        //  In place of the lack of a pause button being set on the controller
        //  NOTE:  Remove once Controller is able to call pause function
        #region Temp Pause Menu Input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause(CurrentGameMode);
        }
        #endregion

        // ISSUE: Timer could potentially be set in a seperate behaviour script  ***
        #region Timer
        //  Timer for when the game isn't paused. Does not tick down while game is paused.
        //  Rt = (St - T) - Pt
        if (Paused == false && CurrentGameMode == GameType.GameMode.PVP)
        {
            RoundTime = (SetTime - Time.timeSinceLevelLoad) - PausedTime;
        }

        //  To not track time while game is "paused".
        //  Pt = (St - T) - Rt
        if (Paused == true && CurrentGameMode == GameType.GameMode.PVP)
        {
            PausedTime = (SetTime - Time.timeSinceLevelLoad) - RoundTime;
        }
        #endregion        
    }

    //  Very Temporary  ***
    public void EnablePause(GameType.GameMode mode)
    {
        // Enables pause menu
        if (Paused == false)
        {
            MenuUI.SetActive(true);
            CharacterChange.SetActive(false);
            Paused = true;
        }

        // Disables pause menu
        else if (Paused == true)
        {
            MenuUI.SetActive(false);
            CharacterChange.SetActive(true);
            Paused = false;
        }
    }
}
