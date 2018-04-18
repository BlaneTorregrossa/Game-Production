using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool FreezeControl;      //  For preveinting character control when true
    public GameType.GameMode CurrentGameMode;   //  Current Game mode for given scene
    public CharacterBehaviour PlayerCharacter;   //  Character Behaviour for Player
    public CharacterBehaviour OpponentCharacter; //  Character Behaviour for Opponent
    public TimerBehaviour Clock;    //  Where everything related to time is used from
    //public CharacterBehaviour TargetCharacter;  //  List of targets in the Target Range

    public List<Round> Rounds;  //  List of results for each individual round
    private bool MenuReturn;    //  When the game is over and we are set to return to the menu
    private bool Paused;    //  For if the game itself is paused

    [SerializeField]
    private int RoundMax;   //  Max amount of rounds for the match. Might need to move to the Round Scriptable Object.
    [SerializeField]
    private GameObject PauseUI; //  Menu based UI that is made avalible once certain conditions are met
    [SerializeField]
    private GameObject ResultScreen;    //  Results screens for after all rounds have occurred
    [SerializeField]
    private GameObject CombatUI; //  For Health, Timer, Etc.
    [SerializeField]
    private Text RoundTimerText; // Timer for Round
    [SerializeField]
    private Text PreRoundTimerText; //  Timer for Preround

    private GlobalGameManager GGM;  //  Used for a timed scene switch


    void Start()
    {
        #region Timer
        Paused = false; //  Game Should Not be puased at the start of the scene
        Clock.TimerObject.Wait = true;  //  Secondary Timer is used first so Wait has to be enabled
        Clock.TimerObject.MainTime = Clock.TimerObject.MainTimeMax; //  Setting Main Time
        Clock.TimerObject.SecondaryTime = Clock.TimerObject.SecondaryTimeMax;   //  Setting Secondary Time
        Clock.TimerObject.TimeReset = 0;    //  Reseting Total time removed
        Time.timeScale = 1.0f;  //  To make sure the scale for time is running at it's standard rate
        #endregion

        GGM = new GlobalGameManager();  //  New Global Game Manager for scene transition
        PlayerCharacter.character.StartingPos = PlayerCharacter.transform.position; //  Position Player started in
        if (CurrentGameMode == GameType.GameMode.PVP)
            OpponentCharacter.character.StartingPos = OpponentCharacter.transform.position; //  Position Opponnent started in

        PauseUI.SetActive(false);   //  Pause UI
        ResultScreen.SetActive(false);  //  End of game UI/ Results UI
        if (CurrentGameMode == GameType.GameMode.PVP)
            CombatUI.SetActive(true);   //  Timer and Health UI
        else
            CombatUI.SetActive(false);  //  Timer and Health UI
    }

    void Update()
    {

        #region Temp Inputs
        //  In place of the lack of a pause button being set on the controller  *
        //  NOTE:  Remove once Controller is able to call pause function
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause();
        }
        #endregion

        #region Timer
        if (Paused == false)
            Clock.UpdateTime(); //  Update Time passed

        RoundTimerText.text = Clock.TimerObject.MainTime.ToString(); //  Round Timer displayed as text

        //  PreRoundTimer is not displayed if player control is enabled
        if (FreezeControl == false && Clock.TimerObject.Wait == false)
            PreRoundTimerText.text = "";
        else
            PreRoundTimerText.text = Clock.TimerObject.SecondaryTime.ToString();
        #endregion

        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            //  For if either character isDead
            if (PlayerCharacter.character.isDead == true || OpponentCharacter.character.isDead == true || Clock.TimerObject.MainTime < 0)
            {
                RoundBehaviour rb = gameObject.AddComponent<RoundBehaviour>();   // Round Behaviour added as a component
                if (PlayerCharacter.character.isDead == true && OpponentCharacter.character.isDead == true)    // if Both PlayerCharacter and OpponnetCharacter are dead
                {
                    RoundMax = rb.Tie(PlayerCharacter, OpponentCharacter, Rounds, RoundMax);   //  Adjust round list
                    Clock.TimerObject.TimeReset += Clock.TimerObject.MainTimeMax - Clock.TimerObject.MainTime;  //  Set time reset since round ended
                }
                else
                {
                    rb.GiveRound(PlayerCharacter, OpponentCharacter, Rounds, RoundMax); //  Decide a winner between the two characters
                    Clock.TimerObject.TimeReset += Clock.TimerObject.MainTimeMax - Clock.TimerObject.MainTime;   //  Set time reset since round ended
                }

                ResetCharacters(PlayerCharacter);   //  Reset Player 1
                ResetCharacters(OpponentCharacter); //  Reset Player 2
                Destroy(rb);    //  Destroys Commponent for Round Behaviour object
               
                #region Time
                Clock.TimerObject.MainTime = 0;  //  Reset Main Timer
                Clock.TimerObject.Wait = true;    //  For Secondary Timer
                #endregion
            }

            if (Rounds.Count >= 3)
            {
                Clock.TimerObject.Wait = true;  //  For Secondary Timer
                MenuReturn = true;  //  Enabled if a return to the main menu is needed
                ResultScreen.SetActive(true);   //  Results Screen Displayed
                CombatUI.SetActive(false);  //  Timer is no longer shown
            }

            else if (Rounds.Count < RoundMax && Clock.TimerObject.SecondaryTime < 0)
            {
                Clock.TimerObject.Wait = false; //  For Main Timer to start
                Clock.TimerObject.TimeReset += Clock.TimerObject.SecondaryTimeMax - Clock.TimerObject.SecondaryTime;    //  Set time reset since the secondary timer reached 0
                Clock.TimerObject.SecondaryTime = 0;
            }

            //  Switch to menu after set amount of time
            if (MenuReturn == true && Clock.TimerObject.SecondaryTime <= 0)
                GGM.GoToScene("257.CharacterSelectTest");   //  Not the main Menu due to lack of Main Menu  *

            //  Setting FreezeControl to the same of Wait
            if (Clock.TimerObject.Wait == true)
                FreezeControl = true;
            else
                FreezeControl = false;
        }

        //else if (CurrentGameMode == GameType.GameMode.TARGETRANGE)
        //{
        //    if (TargetCharacter.character.isDead)
        //    {
        //        ResultScreen.SetActive(true);
        //    }
        //}
    }

    //  Setup Characters for the next round without reseting the scene
    public void ResetCharacters(CharacterBehaviour resetCharacter)
    {
        resetCharacter.character.Health = resetCharacter.characterHealth;    //  Reset Health on the character ScriptableObject
        resetCharacter.character.isDead = false;  //  Character Death check undone
        resetCharacter.transform.position = resetCharacter.character.StartingPos;   //  Bring Character GameObject to the position of assigned Character object
        resetCharacter.gameObject.SetActive(true);    //  Reenabling Characters
    }


    //  Replace when controller function for pausing is added
    //  Temporary    *
    public void EnablePause()
    {
        // Enables pause menu
        if (Paused == false && FreezeControl == false && Clock.TimerObject.Wait == false)
        {
            PauseUI.SetActive(true);
            Paused = true;
            Time.timeScale = 0.0f;
        }

        // Disables pause menu
        else if (Paused == true && FreezeControl == false && Clock.TimerObject.Wait == false)
        {
            PauseUI.SetActive(false);
            Paused = false;
            Time.timeScale = 1.0f;
        }
    }

}
