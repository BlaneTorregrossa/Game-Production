using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*= 
[CreateAssetMenu]
public class Head : ScriptableObject
{
    public string partName;
    public string description;
    public bool canUseSheild;

    public bool createSheild;

    public GameObject prefab;
}
