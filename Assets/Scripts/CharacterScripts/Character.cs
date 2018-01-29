using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{

    public Arm left;
    public Arm Right;
    public string Name;
    public int Heath;
    public int DashCharges;
    public float Speed;
    public float DashSpeed;

    //Placeholders for potential variables
    //public ???? rightArm;
    //public ???? leftArm;
    //public ???? legs;
    //public ???? head;
    
}
