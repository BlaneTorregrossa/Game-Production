﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{

    public Arm Left;
    public Arm Right;
    public string Name;
    public int Heath;
    public int DashCharges;
    public int Push;
    public float Speed;
    public float DashSpeed;
    
}
