using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Timer")]
public class Timer : ScriptableObject
{
    public float TimeReset; //  Time to be removed from the whole time since the start of a scene
    public float MainTime;  //  Main Timer
    public float SecondaryTime; //  Secondary Timer: Please only use if the Main timer is already in use or is on standby
    public int MainTimeMax; //  Max time for the Main Timer to run
    public int SecondaryTimeMax;    //  Max time for the Secondary Tiemr to run
    public bool Wait;   //  For putting Timers on standby
}
