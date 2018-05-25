using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TargetRangeBehaviour : MonoBehaviour
{
    public Target CurrentTarget;

    private GlobalGameManager GGM;  //  Used for a timed scene switch


    void Start()
    {
        GGM = ScriptableObject.CreateInstance<GlobalGameManager>();  //  New Global Game Manager for scene transition
    }

    void Update()
    {
        if (CurrentTarget.Dead == true)
        {
            GGM.GoToScene("1.TargetRange");
        }
    }

}
