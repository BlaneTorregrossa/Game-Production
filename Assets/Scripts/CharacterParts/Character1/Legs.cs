using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parts/Legs")]
public class Legs : Part
{
    public int DashCharges; // Dash Charges given
    public float Speed; //  Speed Modifier
    public float DashSpeed; //  DashSpeed Modifier
}
