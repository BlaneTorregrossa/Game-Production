using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public Arm ArmConfig;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

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
    public void SetProjectile(GameObject po)
    {
        ArmConfig.Projectile.projectile = po;
    }
}
