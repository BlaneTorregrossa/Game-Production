using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public Arm ArmConfig;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {

        }
    }

    public void PerformAttack()
    {
        if(ArmConfig.attackType == Arm.AttackType.FASTMELEE)
        {
            FastMeleeAttack();
        }
        if(ArmConfig.attackType == Arm.AttackType.SLOWMELEE)
        {
            SlowMeleeAttack();
        }
        if(ArmConfig.attackType == Arm.AttackType.BULLET)
        {
            BulletAttack();
        }
        if(ArmConfig.attackType == Arm.AttackType.GRENADE)
        {
            GrenadeAttack();
        }
    }

    private void FastMeleeAttack()
    {
        Debug.Log("Performed Fast Melee Attack");
    }

    private void SlowMeleeAttack()
    {
        Debug.Log("Performed Slow Melee Attack");
    }

    private void GrenadeAttack()
    {
        Debug.Log("Performed Grenade Attack");
    }

    private void BulletAttack()
    {
        Debug.Log("Performed Bullet Attack");
    }
}
