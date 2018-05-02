using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//  Issue: Everything should work without clock unless in an if statement or the start funtion
public class GameLoopBehaviour : MonoBehaviour
{

    [HideInInspector]
    public bool FreezeControl;      //  For preveinting character control when true
    public GameType.GameMode CurrentGameMode;   //  Current Game mode for given scene
    public CharacterBehaviour PlayerCharacter;   //  Character Behaviour for Player
    public CharacterBehaviour OpponentCharacter; //  Character Behaviour for Opponent
    [HideInInspector]
    public TimerBehaviour Clock;    //  Where everything related to time is used from
    public List<Round> Rounds;  //  List of results for each individual round

    #region Events
    public UnityEvent MainTimeEvent;
    public UnityEvent SecondaryTimeEvent;
    public UnityEvent TimeUpdateEvent;
    #endregion

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
        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            #region Timer
            Paused = false; //  Game Should Not be puased at the start of the scene
            Clock = gameObject.GetComponent<TimerBehaviour>();  //  Assigning TimerBehaviour
            Clock.TimerObject.Wait = true;  //  Secondary Timer is used first so Wait has to be enabled
            Clock.TimerObject.MainTime = Clock.TimerObject.MainTimeMax; //  Setting Main Time
            Clock.TimerObject.SecondaryTime = Clock.TimerObject.SecondaryTimeMax;   //  Setting Secondary Time
            Clock.TimerObject.TimeReset = 0;    //  Reseting Total time removed
            Time.timeScale = 1.0f;  //  To make sure the scale for time is running at it's standard rate
            #endregion

            #region Event Listeners
            MainTimeEvent.AddListener(Clock.AddResetTimeMain);
            SecondaryTimeEvent.AddListener(Clock.AddResetTimeSecondary);
            TimeUpdateEvent.AddListener(Clock.UpdateTime);
            #endregion
        }

        GGM = ScriptableObject.CreateInstance<GlobalGameManager>();  //  New Global Game Manager for scene transition
        PlayerCharacter.character.StartingPos = PlayerCharacter.transform.position; //  Position Player started in
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

        if (CurrentGameMode == GameType.GameMode.PVP)
        {
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

            //  For if either character isDead
            if (PlayerCharacter.character.isDead == true || OpponentCharacter.character.isDead == true || Clock.TimerObject.MainTime < 0)
            {
                RoundBehaviour rb = gameObject.AddComponent<RoundBehaviour>();   // Round Behaviour added as a component

                if (PlayerCharacter.character.Health > OpponentCharacter.character.Health || OpponentCharacter.character.Health > PlayerCharacter.character.Health)
                {
                    rb.GiveRound(PlayerCharacter, OpponentCharacter, Rounds, RoundMax); //  Decide a winner between the two characters
                    Clock.AddResetTimeMain();
                }

                else if (PlayerCharacter.character.Health == OpponentCharacter.character.Health)    // if Both PlayerCharacter and OpponnetCharacter havethe same health
                {
                    rb.Tie(PlayerCharacter, OpponentCharacter, Rounds, RoundMax);   //  Give a draw
                    Debug.Log("Player Health " + PlayerCharacter.character.Health + " Opponent Health " + OpponentCharacter.character.Health);
                    Clock.AddResetTimeMain();
                }

                ResetCharacters(PlayerCharacter);   //  Reset Player 1
                ResetCharacters(OpponentCharacter); //  Reset Player 2
                Destroy(rb);    //  Destroys Commponent for Round Behaviour object
            }

            if (Rounds.Count >= 3)
            {
                MenuReturn = true;  //  Enabled if a return to the main menu is needed
                ResultScreen.SetActive(true);   //  Results Screen Displayed
                CombatUI.SetActive(false);  //  Timer is no longer shown
            }

            else if (Rounds.Count < RoundMax && Clock.TimerObject.SecondaryTime < 0)
            {
                Clock.AddResetTimeSecondary();
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
