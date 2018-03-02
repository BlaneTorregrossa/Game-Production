using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{
    public Arm Left;
    public Arm Right;
    public Legs LegSet;
    public Head HeadPiece;
    public bool Display;
    public string Name;
    public int Heatlh;
    public int DashCharges;
    public int Push;
    public float Speed;
    public float DashSpeed;
}
