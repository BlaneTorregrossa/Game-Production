using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    GameObject projectile { get; set; }
}

public interface IShooter
{
    Transform projectileSpawn { get; set; }
    float projectileSpeed { get; set; }
}