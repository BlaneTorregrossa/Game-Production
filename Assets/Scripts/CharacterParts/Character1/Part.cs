using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : ScriptableObject
{
    public string partName;
    public string description;

    public GameObject prefab;
    public Vector3 partPos;
    public SetUpCharacterBehaviour.RobotParts partType;
}
