using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parts/Arm")]
public class Arm : Part
{
    public bool isLeft; //  Check fir if arm belongs on left side of character
    public bool isRight;    //  Check for if arm belongs on right side of character
    public bool isMelee;    //  Check for if arm has melee styled attacks
    public bool isRanged;   //  Check for if arm has ranged styled attacks
    public float meleeDamage;   // Melee Damage Modifier
    public float meleeAttackSpeed;  //  Melee Attack Speed Modifier
    public float projectileDamage;  //  Projectile Damage Modifier
    public float projectileSpeed;   //  Projectile Speed Modifier

    public enum AttackType
    {
        FASTMELEE = 0,
        BULLET = 1,
        GRENADE = 2
    }
    public AttackType attackType;
}
