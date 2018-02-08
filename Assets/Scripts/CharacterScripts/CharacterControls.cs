﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterControls")]
public class CharacterControls : ScriptableObject
{
    public Character characterConfig;
    public MovementBehaviour movement;
    public int gamePadNum;
    public Vector3 moveDirection;
    public Vector3 lookDirection;
    
    public void Move()
    {
        var x = Input.GetAxis("LeftStickX") * characterConfig.Speed;
        var z = Input.GetAxis("LeftStickY") * characterConfig.Speed;
    }

    public void Dash()
    {

    }

    public void Look()
    {

    }
}
