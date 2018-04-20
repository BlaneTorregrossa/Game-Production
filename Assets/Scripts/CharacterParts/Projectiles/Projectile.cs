using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Projectile : ScriptableObject, IShootable
{
    public GameObject projectile { get; set; }
    //public bool explosive { get; set; }
}
