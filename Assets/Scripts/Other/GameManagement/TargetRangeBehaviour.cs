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
        //  Dsiplay buttons if player or all targets are dead, Removes Players and Targets
        if (Targets[0].isDead == true && Targets[1].isDead == true && Targets[2].isDead == true || Character.isDead == true)
        {
            UIChange.SetActive(true);
            CharacterChange.SetActive(false);
        }
    }


}
