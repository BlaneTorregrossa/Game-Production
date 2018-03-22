using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameType")]
public class GameType : ScriptableObject
{

    public enum GameMode
    {
        MENU = 0,
        TARGETRANGE = 1,
        PVP = 2,
    }

    public GameMode Mode;
}
