using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Simple Check Function for if Player or all targets are "Dead " in scene to swich from this scene and back
public class GameLoopBehaviour : MonoBehaviour
{

    public GameType.GameMode CurrentGameMode;
    public CharacterBehaviour Player;
    public CharacterBehaviour Opponent;
    public List<CharacterBehaviour> Targets;
    public GameObject UIChange;
    public GameObject CharacterChange;
    public int RoundTime;
    public int RoundMax;

    [SerializeField]
    private Text Timer;
    private bool Paused;
    private bool StillAlive;
    [SerializeField]
    private List<Round> PlayerRounds;
    [SerializeField]
    private List<Round> OpponentRounds;

    void Start()
    {
        #region Target Range SetUp
        if (CurrentGameMode == GameType.GameMode.TARGETRANGE)
        {
            UIChange.SetActive(false);
            CharacterChange.SetActive(true);
        }
        #endregion

        #region PVP SetUp
        // Set Up rounds
        if (CurrentGameMode == GameType.GameMode.PVP)
        {
            for (int i = 0; i < RoundMax; i++)
            {
                Round newRound = new Round();
                newRound.Tie = false;
                newRound.Won = false;
                newRound.name = "Round " + (i + 1);
                PlayerRounds.Add(newRound);
                OpponentRounds.Add(newRound);
            }
        }
        #endregion

        StillAlive = true;
    }

    void Update()
    {
        // Call for checking if all targets are dead    ***
        if (CurrentGameMode == GameType.GameMode.TARGETRANGE && CheckTargets(Targets) == false)
        {
            UIChange.SetActive(true);
            CharacterChange.SetActive(false);
        }

        #region Temp Pause Menu Input
        // Controller not set to call function yet
        if (Input.GetKeyDown(KeyCode.Escape) && CurrentGameMode == GameType.GameMode.TARGETRANGE)
        {
            EnablePause(CurrentGameMode);
        }
        #endregion
    }

    // Target Range: Check if all targets are dead so menu can be brought up    ***
    public bool CheckTargets(List<CharacterBehaviour> targets)
    {
        for (int i = 0; i < Targets.Count; i++)
        {
            if (Targets[i].isDead == true || Player.isDead == true)
            {
                if (Targets[i].isDead == false && Player.isDead == false)
                {
                    StillAlive = true;
                    return StillAlive;
                }
                StillAlive = false;
            }
        }
        return StillAlive;
    }

    // Need to add: Check for PVP and menu scene and how said pause menus are brought into scene.
    public void EnablePause(GameType.GameMode mode)
    {
        if (mode == GameType.GameMode.TARGETRANGE)
        {
            // Enables pause menu
            if (Paused == false && StillAlive == true)
            {
                UIChange.SetActive(true);
                CharacterChange.SetActive(false);
                Paused = true;
            }

            // Disables pause menu
            else if (Paused == true && StillAlive == true)
            {
                UIChange.SetActive(false);
                CharacterChange.SetActive(true);
                Paused = false;
            }
        }
    }
}
