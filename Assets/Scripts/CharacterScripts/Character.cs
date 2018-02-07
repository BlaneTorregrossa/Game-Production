using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject
{

    public Arm left;
    public Arm right;
    public string name;
    public int heath;
    public int dashCharges;
    public float speed;
    public float dashSpeed;

    //Placeholders for potential variables
    //public ???? rightArm;
    //public ???? leftArm;
    //public ???? legs;
    //public ???? head;
    
}
