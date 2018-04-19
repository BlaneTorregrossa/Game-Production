using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Projectile : ScriptableObject, IShootable
{
    public bool explosive { get; set; }
}
