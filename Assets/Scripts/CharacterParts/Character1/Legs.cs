using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
[CreateAssetMenu]
public class Legs : ScriptableObject
{

    public string partName;
    public string description;
    public bool isBoost;

    public int DashCharges;
    public float Speed;
    public float DashSpeed;

    public GameObject prefab;
}
