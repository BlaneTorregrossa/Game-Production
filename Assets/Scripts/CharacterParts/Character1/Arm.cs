using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  build the parts in the robot space. 
//  Take the character scriptable and build the robot by referencing the individual objects.

[CreateAssetMenu(menuName = "Parts/Arm")]
public class Arm : Part
{
    public bool isLeft;
    public bool isRight;
    public bool isMelee;
    public bool isRanged;
    public float meleeDamage;
    public float meleeAttackSpeed;
    public float projectileDamage;
    public float projectileSpeed;
}
