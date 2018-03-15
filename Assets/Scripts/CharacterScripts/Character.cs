using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public Head HeadPiece;
    public Arm Left;
    public Legs LegSet;
    public Arm Right;
    public string Name;
    public int Heatlh;
    public int DashCharges;
    public float Speed;
    public float DashSpeed;
}
