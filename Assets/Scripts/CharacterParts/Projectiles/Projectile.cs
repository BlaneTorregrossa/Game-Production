using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Projectile : ScriptableObject, IShootable
{
    public GameObject shootableObject { get; set; }
    //public bool explosive { get; set; }
}
