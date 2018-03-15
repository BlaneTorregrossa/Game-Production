using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  build the parts in the robot space. 
//  Take the character scriptable and build the robot by referencing the individual objects.

[CreateAssetMenu(menuName = "Parts/Legs")]
public class Legs : Part
{
    public int DashCharges;
    public float Speed;
    public float DashSpeed;
}
