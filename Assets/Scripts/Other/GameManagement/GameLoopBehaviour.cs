using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameLoopBehaviour : MonoBehaviour
{

    [HideInInspector]
    public bool WaitForTimer;      //  if true player shouldn't move
    public bool GamePause;  //  For if the game is currentlly paused (used for changing timescale or changing gamemode)
    public GameType.GameMode CurrentGameMode;   //  Current Game mode
    public CharacterBehaviour PlayerCharacter;   //  Character Behaviour for Player
    public CharacterBehaviour OpponentCharacter; //  Character Behaviour for Opponent
    [HideInInspector]
    public GlobalGameManager GGM;  //  Used for a timed scene switch
    [HideInInspector]
    public TimerBehaviour Clock;    //  Where everything related to time is used from
    [HideInInspector]
    public List<Round> Rounds;  //  List of results for each individual round
    public List<Menu> Menus;    //  List of all different types of menus that are avalible in current scene ***
    public Menu ActiveMenu;    //  For the Menu object that is currentlly being used, to be assigned and used for if statements    ***

    #region Events
    public UnityEvent MainTimeEvent;
    public UnityEvent SecondaryTimeEvent;
    public UnityEvent TimeUpdateEvent;
    #endregion

    private bool SwitchScene;    //  When the game is over and we are set to return to the menu

    [SerializeField]
    private int RoundMax;   //  Max amount of rounds for the match. Might need to move to the Round Scriptable Object.
    [SerializeField]
    private GameObject PauseUI; //  Menu based UI  that is made avalible once certain conditions are met
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
        Time.timeScale = 1.0f; //  Standard timescale
        GGM = ScriptableObject.CreateInstance<GlobalGameManager>();  //  New Global Game Manager for scene transition
        PlayerCharacter.character.StartingPos = PlayerCharacter.transform.position; //  Position Player started in
        OpponentCharacter.character.StartingPos = OpponentCharacter.transform.position; //  Position Opponnent started in
        GamePause = false;  //  Prevent game starting off paused


        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            #region Timer
            Clock = gameObject.GetComponent<TimerBehaviour>();  //  Assigning TimerBehaviour
            Clock.TimerObject.Wait = true;  //  Secondary Timer is used first so Wait has to be enabled
            Clock.TimerObject.MainTime = Clock.TimerObject.MainTimeMax; //  Setting Main Time
            Clock.TimerObject.SecondaryTime = Clock.TimerObject.SecondaryTimeMax;   //  Setting Secondary Time
            Clock.TimerObject.TimeReset = 0;    //  Reseting Total time removed
            #endregion

            PauseUI.SetActive(false);   //  Pause UI
            ResultScreen.SetActive(false);  //  End of game UI/ Results UI
            CombatUI.SetActive(true);   //  Timer and Health UI

        }

        //  ***
        //  Issue: This is the only scene where I know for sure how which menu should be the activeMenu from the start
        //  Issue: For something like PVP the first Menu you can see can end up being The Pause or Result which are two different menu types
        //  Since scene starts off with a menu it assigns what type of menu should start that scene
        //  In this case, standard for the main menu
        //  GetMenuType takes in a list of Menus and what type of menu is needed and returns that menu
        if (CurrentGameMode == GameType.GameMode.MENU)
        {
            ActiveMenu = GetMenuType(Menus, Menu.MenuType.STANDARD);    //  To get menu of specific type
        }

    }

    void Update()
    {

        //var JoystickNames = Input.GetJoystickNames(); //  Assign Current Joystick names
        //Debug.Log(JoystickNames[1]);  //  Joystick Check

        //  If the currentgame mode is the PVP Game Mode then:
        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            // Disables pause screen and switch back to PVP game Mode
            if (GamePause == false && WaitForTimer == false && Clock.TimerObject.Wait == false)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1.0f;
                CurrentGameMode = GameType.GameMode.PVP;
                ActiveMenu = GetMenuType(Menus, Menu.MenuType.NOMENU);
            }

            // Enables pause screen and switch to the Menu game mode
            else if (GamePause == true && WaitForTimer == false && Clock.TimerObject.Wait == false)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0.0f;
                CurrentGameMode = GameType.GameMode.MENU;
                ActiveMenu = GetMenuType(Menus, Menu.MenuType.PAUSEMENU);
            }

            #region Timer
            if (GamePause == false)
                TimeUpdateEvent.Invoke(); //  Update Time passed

            RoundTimerText.text = Clock.TimerObject.MainTime.ToString(); //  Round Timer displayed as text

            //  PreRoundTimer is not displayed if player control is enabled
            if (WaitForTimer == false && Clock.TimerObject.Wait == false)
                PreRoundTimerText.text = "";
            else
                PreRoundTimerText.text = Clock.TimerObject.SecondaryTime.ToString();
            #endregion

            //  For if either character isDead or if time ran out:
            //  Create a new RoundBehaviour
            //  Check characters health and call either a tie or a winner and then update the time accorrdigally
            //  Thene reset both characters and destroy the new RoundBehaviour
            //  If the rounds excede the max round count then the prep for switching back to the main menu is set up
            //  If the secondary timer runs out and round max has not been hit yet then a new round starts else when the timer runs out the scenes are swapped
            //  IF timer is set to wait than certain functions would not be called
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
                SwitchScene = true;  //  Enabled if a return to the main menu is needed
                ResultScreen.SetActive(true);   //  Results Screen Displayed
                CombatUI.SetActive(false);  //  Timer is no longer shown
                //CurrentGameMode = GameType.GameMode.MENU; //  Prevents timer  ***
                ActiveMenu = GetMenuType(Menus, Menu.MenuType.ENDGAME);    //  The type of menu to be made avalible for controllers to navigate    ***
            }

            else if (Rounds.Count < RoundMax && Clock.TimerObject.SecondaryTime < 0)
            {
                SecondaryTimeEvent.Invoke();
            }

            //  Switch to Customization Menu after set amount of time
            if (SwitchScene == true && Clock.TimerObject.SecondaryTime <= 0)
                GGM.GoToScene("257.CharacterSelectTest");   //  Not the main Menu due to lack of Main Menu  *

            //  Setting FreezeControl to the same of Wait
            if (Clock.TimerObject.Wait == true)
                WaitForTimer = true;
            else
                WaitForTimer = false;
        }

        //  Switch from PVP to Menu on Pause
        if (CurrentGameMode == GameType.GameMode.MENU && ActiveMenu.Type == Menu.MenuType.PAUSEMENU)
        {

            // Disables pause screen and switch back to PVP game Mode
            if (GamePause == false && WaitForTimer == false && Clock.TimerObject.Wait == false)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1.0f;
                CurrentGameMode = GameType.GameMode.PVP;
                ActiveMenu = GetMenuType(Menus, Menu.MenuType.NOMENU);
            }

            // Enables pause screen and switch  to MENU game Mode
            else if (GamePause == true && WaitForTimer == false && Clock.TimerObject.Wait == false)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0.0f;
                CurrentGameMode = GameType.GameMode.MENU;
                ActiveMenu = GetMenuType(Menus, Menu.MenuType.PAUSEMENU);
            }
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

    //  To return Menu in list based on type
    public Menu GetMenuType(List<Menu> givenMenus, Menu.MenuType targetType)
    {
        Menu returnType = null;

        for (int i = 0; i < givenMenus.Count; i++)
        {
            if (givenMenus[i].Type == targetType)
                returnType = givenMenus[i];
        }

        return returnType;
    }
}
