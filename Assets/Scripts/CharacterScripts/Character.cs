using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{
    public List<Part> parts;
    void OnEnable()
    {
        parts = new List<Part>() { Left, Right, LegSet, HeadPiece };
    }

    public Part Left;
    public Part Right;
    public Part LegSet;
    public Part HeadPiece;
    public string Name;
    public int Health;
    public int DashCharges;
    public float Speed;
    public float DashSpeed;
}
