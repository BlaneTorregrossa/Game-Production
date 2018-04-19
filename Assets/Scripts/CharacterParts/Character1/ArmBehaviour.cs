using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public Arm ArmConfig;
    public FireProjectileBehaviour BulletShooter;

    private void Start()
    {
        SetExplosive();
    }

    // Update is called once per frame
    private void Update()
    {

    }
    
    private void SetExplosive()
    {
        if(ArmConfig.isExplosive)
        {
            ArmConfig.Projectile.explosive = true;
        }
        else
        {
            ArmConfig.Projectile.explosive = false;
        }
    }
}
