﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIEFramework;

public class TimerBehaviour : MonoBehaviour
{

    public Timer TimerObject;   //  To use the variables needed for a timer
    public GameEventArgsListener PrimaryTimeResetListener;  //  Listener for the Primary Timer Reset    ***

    private GameLoopBehaviour GLB;  //  For GameEvebts

    void Start()
    {
        GLB = gameObject.GetComponent<GameLoopBehaviour>(); //  ***
        PrimaryTimeResetListener = gameObject.GetComponent<GameEventArgsListener>();    //  ***
        PrimaryTimeResetListener.Event = GLB.ActivatePrimaryTimeReset;    //  ***
        PrimaryTimeResetListener.Sender = this;    //  ***
        PrimaryTimeResetListener.Sender.name = "Timer"; //  ***
    }

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
        TimerObject.TimeReset += TimerObject.MainTimeMax - TimerObject.MainTime;
        TimerObject.MainTime = 0;
    }

    //  Incraeasing Time difference based on Secondary Timer
    public void AddResetTimeSecondary()
    {
        TimerObject.TimeReset += TimerObject.SecondaryTimeMax - TimerObject.SecondaryTime;
        TimerObject.SecondaryTime = 0;
    }
}
