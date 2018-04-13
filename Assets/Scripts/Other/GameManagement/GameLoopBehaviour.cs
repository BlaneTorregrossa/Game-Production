using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool Wait;      //  Wait for round to start
    public GameType.GameMode CurrentGameMode;   //  Current Game mode for given scene
    public CharacterBehaviour PlayerCharacter;   //  Character Behaviour for Player
    public CharacterBehaviour OpponentCharacter; //  Character Behaviour for Opponent
    public List<CharacterBehaviour> TargetCharacters;    //  List of targets in the Target Range
    public List<Round> Rounds;  //  List of results for each individual round

    [SerializeField]
    private float TimeReset;    //  Reset timer for return to 
    [SerializeField]
    private float RoundTime;    //  Time for each Round
    [SerializeField]
    private float PausedTime;   //  Time while paused
    [SerializeField]
    private float PreRoundTime;     //  For Pre or Post Round Wait
    private bool Paused;    //  For determining if game is paused
    [SerializeField]
    private int RoundMax;   //  Max amount of rounds for the match. Might need to move to the Round Scriptable Object.
    [SerializeField]
    private float RoundTimeMax;  //  Starting time for round
    [SerializeField]
    private float PreRoundTimeMax;  //  Max for wait time
    [SerializeField]
    private GameObject MenuUI; //  Menu based UI that is made avalible once certain conditions are met
    [SerializeField]
    private GameObject Characters;  //   Character objects in the scene
    [SerializeField]
    private GameObject ResultScreen;    //  Results screens for after all rounds have occurred
    [SerializeField]
    private GameObject CombatUI; //  For Health, Timer, Etc.
    [SerializeField]
    private Text RoundTimerText; // Timer for Round
    [SerializeField]
    private Text PreRoundTimerText; //  Timer for Preround


    void Start()
    {
        Wait = true;
        RoundTime = RoundTimeMax;
        PreRoundTime = PreRoundTimeMax;
        TimeReset = 0;
        PausedTime = 0;
        PlayerCharacter.character.StartingPos = PlayerCharacter.transform.position; //  Position Player started in
        OpponentCharacter.character.StartingPos = OpponentCharacter.transform.position; //  Position Opponnent started in

        MenuUI.SetActive(false);
        Characters.SetActive(true);
        ResultScreen.SetActive(false);
        CombatUI.SetActive(true);
    }

    void Update()
    {

        #region Temp Inputs
        //  In place of the lack of a pause button being set on the controller
        //  NOTE:  Remove once Controller is able to call pause function
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause(CurrentGameMode);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TempDamage();
        }
        #endregion



        //  Timer Broken, Needs Revision, Might make it's own behaviour ***
        #region Timer
        //  Round timer ***
        if (CurrentGameMode == GameType.GameMode.PVP && Wait == false && Paused == false && Rounds.Count <= RoundMax)
            RoundTime = RoundTimeMax - (Time.timeSinceLevelLoad - TimeReset);

        //  Preround timer  ***
        if (CurrentGameMode == GameType.GameMode.PVP && Wait == true && Paused == false && Rounds.Count <= RoundMax)
            PreRoundTime = PreRoundTimeMax - (Time.timeSinceLevelLoad - TimeReset);

        //  Pause screen timer  ***
        if (CurrentGameMode == GameType.GameMode.PVP && Wait == false && Paused == true && Rounds.Count <= RoundMax)
            PausedTime = (Time.timeSinceLevelLoad - RoundTime) - TimeReset;

        RoundTimerText.text = RoundTime.ToString();

        if (PreRoundTime <= 0)
            PreRoundTimerText.text = "";
        else
            PreRoundTimerText.text = PreRoundTime.ToString();
        #endregion

        //  For if either character isDead
        if (PlayerCharacter.character.isDead == true || OpponentCharacter.character.isDead == true || RoundTime < 0)
        {
            RoundBehaviour rb = gameObject.AddComponent<RoundBehaviour>();   // Round Behaviour added as a component
            if (PlayerCharacter.character.isDead == true && OpponentCharacter.character.isDead == true)    // if Both PlayerCharacter and OpponnetCharacter are dead
            {
                //RoundMax = rb.Tie(PlayerCharacter, OpponentCharacter, Rounds, RoundMax);   //  Adjust round list
                TimeReset += RoundTimeMax - RoundTime;
            }
            else
            {
                rb.GiveRound(PlayerCharacter, OpponentCharacter, Rounds, RoundMax); //  Decide a winner between the two characters
                TimeReset += RoundTimeMax - RoundTime;  //  Set Reset for RoundTime, WaitTime, and PausedTime
            }
            ResetCharacters(PlayerCharacter);   //  Reset Player 1
            ResetCharacters(OpponentCharacter); //  Reset Player 2
            Destroy(rb);    //  Destroys Commponent for Round Behaviour object
            Wait = true;    //  For Wait Timer
        }

        if (Rounds.Count >= 3)
        {
            Wait = true;
            ResultScreen.SetActive(true);
            CombatUI.SetActive(false);
        }
        else if (Rounds.Count < RoundMax && PreRoundTime < 0)
        {
            Wait = false;
            TimeReset += PreRoundTimeMax;
            PreRoundTime = 0;
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
    //  Temporary    ***
    public void EnablePause(GameType.GameMode mode)
    {
        // Enables pause menu
        if (Paused == false && Wait == false)
        {
            MenuUI.SetActive(true);
            Characters.SetActive(false);
            Paused = true;
        }

        // Disables pause menu
        else if (Paused == true && Wait == false)
        {
            MenuUI.SetActive(false);
            Characters.SetActive(true);
            Paused = false;
        }
    }

    public void TempDamage()
    {
        PlayerCharacter.character.Health -= 50;
    }

}
