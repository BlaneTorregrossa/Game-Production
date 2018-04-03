using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{
    public List<Part> parts;    //  List of Character Parts
    void OnEnable() 
    {
        parts = new List<Part>() { Left, Right, LegSet, HeadPiece };    // New up List of Character Parts
    }

    public Part Left;   //  Left Arm Part
    public Part Right;  //  Right Arm Part
    public Part LegSet; //  Legs Part
    public Part HeadPiece;  //  Head Part
    public string Name; //  Name for character (EX: Player 1 or P1)
    public float Health;  //  Set health for character
    public int DashCharges; //  Dashes avalible for character
    public float Speed; //  Default speed for the character
    public float DashSpeed; //  Default dash speed for the character


    public ArmBehaviour LeftArmBehaviour;
    public ArmBehaviour RightArmBehaviour;
    public HeadBehaviour HeadBehaviour;
}
