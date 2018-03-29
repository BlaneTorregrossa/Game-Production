using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ScriptableObject
{
    public float speed;
    public float damage;
    public string tag;
    public Vector3 force;
    public Vector3 position;
}
