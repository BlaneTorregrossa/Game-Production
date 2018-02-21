using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
[CreateAssetMenu]
public class Arm : ScriptableObject
{
    public bool isLeft;
    public bool isRight;
    public bool isMelee;
    public bool isRanged;

    public int meleeDamage;
    public float meleeAttackSpeed;
    public int projectileDamage;
    public int projectileSpeed;

    public Vector3 armPos;
}
