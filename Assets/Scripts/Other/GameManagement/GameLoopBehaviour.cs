using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <TO_DO>
/// Have the start of each round to disable all charater controls except for the Look.
/// Once a round "Starts", renable all character controls
/// Have a seperate timer for the round start
/// ISSUE: Timer could potentially be set in a seperate behaviour script  ***
/// </TO_DO>
public class GameLoopBehaviour : MonoBehaviour
{
    public GameType.GameMode CurrentGameMode;   //  Current Game mode for given scene
    public CharacterBehaviour PlayerCharacter;   //  Character Behaviour for Player
    public CharacterBehaviour OpponentCharacter; //  Character Behaviour for Opponent
    public List<CharacterBehaviour> TargetCharacters;    //  List of targets in the Target Range
    public List<Round> Rounds;  //  List of results for each individual round

    private float TimeReset;
    [SerializeField]
    private bool Wait;      //  Wait for round to start
    [SerializeField]
    private bool Paused;    //  For determining if game is paused
    [SerializeField]
    private int RoundMax;   //  Max amount of rounds for the match. Might need to move to the Round Scriptable Object.
    [SerializeField]
    private float RoundTimeMax;  //  Starting time for round
    [SerializeField]
    private float RoundTime;    //  Time for each Round
    [SerializeField]
    private float PausedTime;   //  Time while paused
    [SerializeField]
    private float WaitTimeMax;  //  Max for wait time
    [SerializeField]
    private float WaitTime;     //  For Pre or Post Round Wait
    [SerializeField]
    private GameObject MenuUI; //  Menu based UI that is made avalible once certain conditions are met
    [SerializeField]
    private GameObject CharacterChange;  //   Character objects in the scene

    void Start()
    {
        PlayerCharacter.character.StartingPos = PlayerCharacter.transform.position;
        OpponentCharacter.character.StartingPos = OpponentCharacter.transform.position;

        #region Target Range Start
        //  Disables Pause menu, enable characters
        if (CurrentGameMode == GameType.GameMode.TARGETRANGE)
        {
            MenuUI.SetActive(false);    //  Temporary   ***
            CharacterChange.SetActive(true);    //  Temporary   ***
        }
        #endregion

        #region PVP Start
        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            TimeReset = 0;
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

        //  Round Time initiated
        if (CurrentGameMode == GameType.GameMode.PVP && Wait == false && Paused == false)
        {
            RoundTime = (Time.timeSinceLevelLoad - PausedTime) - TimeReset;
        }

        //  Wait for new round Timer initiated
        if (CurrentGameMode == GameType.GameMode.PVP && Wait == true && Paused == false)
        {
            WaitTime = (Time.timeSinceLevelLoad - PausedTime) - TimeReset;
        }

        //  Pause screen timer initiated
        if (CurrentGameMode == GameType.GameMode.PVP && Wait == false && Paused == true)
        {
            PausedTime = (Time.timeSinceLevelLoad - (WaitTime + RoundTime)) - TimeReset; 
        }

        #region Timer / Abandoned
        ////  Time for the round
        //if (CurrentGameMode == GameType.GameMode.PVP && Wait == false && Paused == false)
        //{
        //    RoundTime = (RoundTimeMax - Time.timeSinceLevelLoad) - PausedTime;
        //}
        ////  Time for the prep for the round
        //if (CurrentGameMode == GameType.GameMode.PVP && Wait == true && Paused == false)
        //{
        //    WaitTime = (WaitTimeMax - Time.timeSinceLevelLoad) - PausedTime;
        //}
        ////  Time for when the game is paused
        //if (CurrentGameMode == GameType.GameMode.PVP && Wait == false && Paused == true)
        //{
        //    PausedTime = Time.timeSinceLevelLoad - (WaitTime + RoundTime);
        //}
        #endregion

        #region Previous Timer / Bad Made Up Math
        ////  Timer for when the game isn't paused. Does not tick down while game is paused.
        ////  Rt = (RTM - T) - Pt
        //if (Paused == false && CurrentGameMode == GameType.GameMode.PVP && Wait == false)
        //    RoundTime = (RoundTimeMax - Time.timeSinceLevelLoad) - PausedTime;

        ////  To not track time while game is "paused".
        ////  Pt = (RTM - T) - Rt
        //if (Paused == true && CurrentGameMode == GameType.GameMode.PVP && Wait == false)
        //    PausedTime = (RoundTimeMax - Time.timeSinceLevelLoad) - RoundTime;

        ////  Not matter the setup cannot make work   ***
        ////  Need to Change how PausedTime and RoundTime are tracked ***
        //if (Paused == false && CurrentGameMode == GameType.GameMode.PVP && Wait == true)
        //    WaitTime = (WaitTimeMax - Time.timeSinceLevelLoad) - WaitTime;
        #endregion

        //  Should Be Replaced
        //  For if either character isDead
        if (PlayerCharacter.isDead == true || OpponentCharacter.isDead == true || RoundTime >= RoundTimeMax)
        {
            RoundBehaviour rb = gameObject.AddComponent<RoundBehaviour>();   // Round Behaviour added as a component
            if (PlayerCharacter.isDead == true && OpponentCharacter == true)    // if Both PlayerCharacter and OpponnetCharacter are dead
                RoundMax = rb.Tie(PlayerCharacter, OpponentCharacter, Rounds, RoundMax);   //  Adjust round list 
            else
                rb.GiveRound(PlayerCharacter, OpponentCharacter, Rounds, RoundMax); //  Decide a winner between the two characters
            ResetCharacters(PlayerCharacter);   //  Reset Player 1
            ResetCharacters(OpponentCharacter); //  Reset Player 2
            Destroy(rb);    //  Destroys Commponent for Round Behaviour object
            Wait = true;    //  Change  ***
        }

        //  Change  ***
        if (WaitTime <= 0 && Wait == true)
        {
            Wait = false;
        }
    }

    //  Setup Characters for the next round without reseting the scene
    public void ResetCharacters(CharacterBehaviour resetCharacter)
    {
        resetCharacter.Health = resetCharacter.character.Health;    //  Reset Health on the character Behaviour
        resetCharacter.isDead = false;  //  Character Death check undone
        resetCharacter.transform.position = resetCharacter.character.StartingPos;   //  Bring Character GameObject to the position of assigned Character object
        resetCharacter.gameObject.SetActive(true);    //  Reenabling Characters
    }


    //  Replace when controller function for pausing is added
    //  Temporary    ***
    public void EnablePause(GameType.GameMode mode)
    {
        // Enables pause menu
        if (Paused == false && Wait == false)
        {
            MenuUI.SetActive(true);
            CharacterChange.SetActive(false);
            Paused = true;
        }

        // Disables pause menu
        else if (Paused == true && Wait == false)
        {
            MenuUI.SetActive(false);
            CharacterChange.SetActive(true);
            Paused = false;
        }
    }

}
