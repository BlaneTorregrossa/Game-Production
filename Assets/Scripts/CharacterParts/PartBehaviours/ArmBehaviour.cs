using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public Arm ArmConfig;

    private void Start()
    {
        SetShootable();
    }

    // Update is called once per frame
    private void Update()
    {

    }
    
    private void SetShootable()
    {
        ArmConfig.Projectile.projectile = ArmConfig.projectileObject;
    }

    private void SetToExplode()
    {
        if(ArmConfig.isExplosive)
        {
            
        }
        else
        {
            
        }
    }

    public void PerformAttack()
    {

    }
}
