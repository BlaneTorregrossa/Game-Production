using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//  Issue: Everything should work without clock unless in an if statement or the start funtion
public class GameLoopBehaviour : MonoBehaviour
{

    [HideInInspector]
    public bool WaitForTimer;      //  For preveinting character control when true
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
    private int RoundMax;   //  Max amount of rounds for the match. Might need to move to the Round Scriptable 
    [SerializeField]
    private GameObject PreRoundTimerObject; //  For Health, Timer, Etc.
    [SerializeField]
    private Text RoundTimerText; // Timer for Round
    [SerializeField]
    private Text PreRoundTimerText; //  Timer for Preround
    private GlobalGameManager GGM;  //  Used for a timed scene switch
    [SerializeField]
    private GameObject Results;
    [SerializeField]
    private Text WinnerText;

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
        }

        Results.SetActive(false);
        GGM = ScriptableObject.CreateInstance<GlobalGameManager>();  //  New Global Game Manager for scene transition
        PlayerCharacter.character.StartingPos = PlayerCharacter.transform.position; //  Position Player started in
        OpponentCharacter.character.StartingPos = OpponentCharacter.transform.position; //  Position Opponnent started in

        if (CurrentGameMode == GameType.GameMode.PVP)
            PreRoundTimerObject.SetActive(true);   //  Timer and Health UI
        else
            PreRoundTimerObject.SetActive(false);  //  Timer and Health UI
    }

    void Update()
    {

        //var JoystickNames = Input.GetJoystickNames();
        //Debug.Log(JoystickNames[1]);

        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            
            #region Timer
            if (Paused == false)
                TimeUpdateEvent.Invoke(); //  Update Time passed

            RoundTimerText.text = Clock.TimerObject.MainTime.ToString(); //  Round Timer displayed as text

            //  PreRoundTimer is not displayed if player control is enabled
            if (WaitForTimer == false && Clock.TimerObject.Wait == false)
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
                    MainTimeEvent.Invoke();
                }

                else if (PlayerCharacter.character.Health == OpponentCharacter.character.Health)    // if Both PlayerCharacter and OpponnetCharacter havethe same health
                {
                    rb.Tie(PlayerCharacter, OpponentCharacter, Rounds, RoundMax);   //  Give a draw
                    Debug.Log("Player Health " + PlayerCharacter.character.Health + " Opponent Health " + OpponentCharacter.character.Health);
                    MainTimeEvent.Invoke();
                }

                ResetCharacters(PlayerCharacter);   //  Reset Player 1
                ResetCharacters(OpponentCharacter); //  Reset Player 2
                Destroy(rb);    //  Destroys Commponent for Round Behaviour object
            }

            if (Rounds.Count >= 3)
            {
                MenuReturn = true;  //  Enabled if a return to the main menu is needed
                PreRoundTimerObject.SetActive(false);  //  Timer is no longer shown
            }

            else if (Rounds.Count < RoundMax && Clock.TimerObject.SecondaryTime < 0)
            {
                SecondaryTimeEvent.Invoke();
            }

            //  Switch to menu after set amount of time
            if (MenuReturn == true && Clock.TimerObject.SecondaryTime <= 3)
            {
                WinnerText.text = DisplayWinner(PlayerCharacter.character, OpponentCharacter.character).Name + "  has  Won!";
                if (WinnerText.text == "")
                    WinnerText.text = "It's  a  Draw!";
                Results.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GGM.GoToScene(SceneToLoad);   //  Not the main Menu due to lack of Main Menu  *
                }
            }

            //  Setting FreezeControl to the same of Wait
            if (Clock.TimerObject.Wait == true)
                WaitForTimer = true;
            else
                WaitForTimer = false;
        }
    }

    //  Setup Characters for the next round without reseting the scene
    public void ResetCharacters(CharacterBehaviour resetCharacter)
    {
        //resetCharacter.character.Health = resetCharacter.characterHealth;    //  Reset Health on the character ScriptableObject
        //resetCharacter.character.isDead = false;  //  Character Death check undone
        resetCharacter.ResetCharacter(); // Resets Health, Death boolean, and the Cooldown for bullets
        resetCharacter.transform.position = resetCharacter.character.StartingPos;   //  Bring Character GameObject to the position of assigned Character object
        resetCharacter.gameObject.SetActive(true);    //  Reenabling Characters
    }

    public Character DisplayWinner(Character characterA, Character characterB)
    {
        Character ReturnVar = new Character();

        int PlayerAWins = 0;
        int PlayerBWins = 0;

        for (int i = 0;  i < Rounds.Count; i++)
        {
            if (Rounds[i].Result == Round.RoundResult.CHARACTERAWIN)
                PlayerAWins += 1;
            if (Rounds[i].Result == Round.RoundResult.CHARACTERBWIN)
                PlayerBWins += 1;
        }

        if (PlayerAWins > PlayerBWins)
            ReturnVar = characterA;
        if (PlayerBWins > PlayerAWins)
            ReturnVar = characterB;
        if (PlayerAWins == PlayerBWins)
            ReturnVar.name = "";

        return ReturnVar;
    }

    public string SceneToLoad = "257.CharacterSelectTest";
}
