using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterControls")]
public class CharacterControls : ScriptableObject
{
    public int gamePadNum;
    public Vector3 moveDirection;
    public Vector3 dashDirection;
    public Vector3 lookDirection;
    
    public void Move(float x, float z)
    {
        moveDirection = new Vector3(x, 0, z);
    }

    public void Dash(float x, float z)
    {
        dashDirection = new Vector3(x, 0, z);
    }

    public void Look(float x, float z)
    {
        lookDirection = new Vector3(x, 0, z);
    }
}
