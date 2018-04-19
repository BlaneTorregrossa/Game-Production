using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Projectile : ScriptableObject, IShootable
{
    public float speed;
    public string tag;
    public Vector3 force;
    public Vector3 position;
}
