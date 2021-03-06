﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour, IFireable
{
    private IFireable Fireable { get { return ArmConfig; } }
    private IDamager Damager { get { return ArmConfig; } }

    public Arm ArmConfig;

    private void SetToExplode()
    {
        if (ArmConfig.isExplosive)
        {

        }
        else
        {

        }
    }

    public void PerformAttack()
    {

    }

    public void SetProjectileObject(GameObject o)
    {
        ArmConfig.projectile.Prefab = o;
    }
    
    public void Fire(Transform owner, Transform position, IDamager damager)
    {
        Fireable.Fire(owner, position, damager);
    }
    
}