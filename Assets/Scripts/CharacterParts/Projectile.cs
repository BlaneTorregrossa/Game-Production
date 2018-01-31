using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Projectile : ScriptableObject
{
    public float speed;

    public Vector3 force;
    public Vector3 position;
}
