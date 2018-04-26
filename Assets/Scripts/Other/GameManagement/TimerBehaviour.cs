using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using AIEFramework;

public class TimerBehaviour : MonoBehaviour
{

    public Timer TimerObject;   //  To use the variables needed for a timer

    public void UpdateTime()
    {
        //  If wait is false Main Timer runs, if wait is true than Secondary Timer runs
        if (TimerObject.Wait == false)
        {
            TimerObject.MainTime = TimerObject.MainTimeMax - (Time.timeSinceLevelLoad - TimerObject.TimeReset); // Counting down with main timer
            TimerObject.SecondaryTime = TimerObject.SecondaryTimeMax;   // Setting Secondary Timer
        }

        if (TimerObject.Wait == true)
        {
            TimerObject.SecondaryTime = TimerObject.SecondaryTimeMax - (Time.timeSinceLevelLoad - TimerObject.TimeReset);   //  Counting down with secondary timer
            TimerObject.MainTime = TimerObject.MainTimeMax; //  Setting Main timer
        }
    }

    //  Increasing Time difference bassed on Main Timer
    public void AddResetTimeMain()
    {
        TimerObject.TimeReset += TimerObject.MainTimeMax - TimerObject.MainTime;    //  Sets reset time based on difference from MainTimeMax and the MainTime at the moment the function is called
        TimerObject.MainTime = 0;   //  Safety
        TimerObject.Wait = true;    //  Enable Wait for secondary timer
    }

    //  Incraeasing Time difference based on Secondary Timer
    public void AddResetTimeSecondary()
    {
        TimerObject.TimeReset += TimerObject.SecondaryTimeMax - TimerObject.SecondaryTime;//  Sets reset time based on difference from SeondaryTimeMax and the SecondaryTime at the moment the function is called
        TimerObject.SecondaryTime = 0;  //  Saftey
        TimerObject.Wait = false;   //  Disable Wait for Secondary Timer
    }
}
