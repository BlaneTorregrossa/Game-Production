using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    
}

public interface IShooter
{
    GameObject projectile { get; set; }
    float projectilespeed { get; set; }

    void ShootProjectile(IShootable shootable);
}