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
    
    public void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        moveDirection = new Vector3(x, 0, z);
    }

    public void Dash()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
    }

    public void Look()
    {
        var x = Input.GetAxis("LookHorizontal");
        var z = Input.GetAxis("LookVertical");
        lookDirection = new Vector3(x, 0, z);
    }
}
