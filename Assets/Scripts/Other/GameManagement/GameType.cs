using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For determining set gamemode of selected scene
[CreateAssetMenu(menuName = "GameType")]
public class GameType : ScriptableObject
{

    public enum GameMode
    {
        MENU = 0,           //  Main Menu
        TESTING = 1,    //  For Testing
        PVP = 2,            //  For Character Vs Character Scene
    }

    public GameMode Mode;   //  If this sciptable object is made into it's own asset    (Not Recomended)
}
