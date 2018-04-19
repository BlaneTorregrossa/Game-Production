using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    
}

public interface IShooter
{
    GameObject projectile { get; set; }
    Transform projectileSpawn { get; set; }
    float projectileSpeed { get; set; }
}