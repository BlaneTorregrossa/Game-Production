using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    [SerializeField] public Vector3 Position;
    [SerializeField] public float Health;
}
