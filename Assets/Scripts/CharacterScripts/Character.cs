using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{
    public Part Left;
    public Part Right;
    public Part LegSet;
    public Part HeadPiece;
    public List<Part> CharacterParts;
    public string Name;
    public int Heatlh;
    public int DashCharges;
    public float Speed;
    public float DashSpeed;
}
