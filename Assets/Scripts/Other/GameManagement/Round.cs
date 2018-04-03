using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : ScriptableObject
{

    public enum RoundResult //  Result for each Round
    {
        UNDECIDED = 0,
        CHARACTERAWIN = 1,
        CHARACTERBWIN = 2,
        DRAW = 3,
    }

    public RoundResult Result;

    //  ----------------------------------------------------------------------------------------

    //public bool Won;    // Check if Player won given Round
    //public bool Loss;   // Check if Player Loss given Round
    //public bool Draw;    // Check if Player tied given Round
}
