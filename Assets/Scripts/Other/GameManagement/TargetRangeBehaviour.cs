using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Simple Check Function for if Player or all targets are "Dead " in scene to swich from this scene and back
public class TargetRangeBehaviour : MonoBehaviour
{

    public GlobalGameManager GameManagerInstance;
    public GameType CurrentGameMode;
    public CharacterBehaviour Character;
    public List<CharacterBehaviour> Targets;
    public GameObject UIChange;
    public GameObject CharacterChange;

    [SerializeField]
    private Text Timer;
    private bool Paused;
    private bool Reload;

    void Start()
    {
        UIChange.SetActive(false);
        CharacterChange.SetActive(true);

        //  Check for Correct Scene Type. If wrong type, switches back to Character Select Menu
        if (CurrentGameMode.Mode != GameType.GameMode.TARGETRANGE)
        {
            Debug.Log("Incorrect Game Mode set for this scene. What is given: " + CurrentGameMode.Mode);
            GameManagerInstance.GoToScene("257.CharacterSelectTest");
        }




    }

    void Update()
    {
        #region Time
        if (Paused == false)
        {
            Time.timeScale = 1;
            Timer.text = "Time: " + Time.timeSinceLevelLoad;
        }

        else if (Paused == true)
            Time.timeScale = 0;
        #endregion

        //  Dsiplay buttons if player or all targets are dead, Removes Players and Targets
        if (Targets[0].isDead == true && Targets[1].isDead == true && Targets[2].isDead == true || Character.isDead == true)
        {
            Paused = true;
            UIChange.SetActive(true);
            CharacterChange.SetActive(false);
        }

        // Controller not set to call function yet
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePauseMenu();
        }
    }

    // A simple Pause menu for user to restart scene, change the character, or quit the game
    public void EnablePauseMenu()
    {
        // Enables pause menu
        if (Paused == false &&
            Targets[0].isDead == false && Targets[1].isDead == false && Targets[2].isDead == false
            && Character.isDead == false)
        {
            UIChange.SetActive(true);
            CharacterChange.SetActive(false);
            Paused = true;
        }

        // Disables pause menu
        else if (Paused == true &&
            Targets[0].isDead == false && Targets[1].isDead == false && Targets[2].isDead == false
            && Character.isDead == false)
        {
            UIChange.SetActive(false);
            CharacterChange.SetActive(true);
            Paused = false;
        }
    }
}
