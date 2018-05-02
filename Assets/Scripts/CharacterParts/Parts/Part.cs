using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  build the parts in the robot space. 
//  Take the character scriptable and build the robot by referencing the individual objects.

public class Part : ScriptableObject
{
    public string partName;
    public string description;
    public GameObject prefab;    
    public Vector3 partPos;
    public SetUpCharacterBehaviour.RobotParts partType;
}
