using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCharacterBehaviour : MonoBehaviour
{
    //  For setting how part gameObjects are brought into the scene. Order should be (going clockwise):
    //  HEAD, LEFTARM, LEGS, RIGHTARM
    public enum RobotParts
    {
        HEAD = 0,
        LEFTARM = 1,
        LEGS = 2,
        RIGHTARM = 3
    }

    #region Parts
    [HideInInspector]
    public GameObject ArmAttachLeft;    // Gameobject for left arm attachment point
    [HideInInspector]
    public GameObject ArmAttachRight;   // Gameobject for right arm attachment point
    [HideInInspector]
    public GameObject LegsAttach;   // Attach point for the legs gameobject
    [HideInInspector]
    public GameObject HeadAttach;   // Attach point for head gameobject
    #endregion
    public List<GameObject> RobotPartObjectList;    //  List of GameObjects attached to Character GameObject, Sorted in set order
    public Character CurrentCharacter;  //  Character Scriptable object

    // Creating expected points for the parts to be placed
    public GameObject SetupAttachPoints(Vector3 offset)
    {
        var quarterScale = new Vector3(.1f, .1f, .1f);   //  Setting scale of the attach point to be small, SHOULDN'T BE VISIBLEONCE PARTS ARE PLACED
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);    //  GameObject representation of point
        go.name = "Attach Point";   //  To label as attach point in inspector
        go.transform.localScale = quarterScale; //  Assigning sacle of the attach point
        go.transform.SetParent(transform);  //  Sets attach point's parent
        go.transform.localPosition = offset;    //  Set offset of attachpoint in relation to it's parent
        Destroy(go.GetComponent<BoxCollider>());    //  Removes box collider
        return go;  // Return
    }

    //  Position parts based on the part object given as well as the scale, offset, and PartType 
    public void GetPart(Part part, GameObject partObject, Vector3 scale, Vector3 offset, RobotParts piece)
    {
        int pieceNum = (int)piece;  //  get int value from given enum
        var go = Instantiate(partObject);  //  Instantiates arm gameobject as assigned prefab
        go.transform.SetParent(transform);  //  Set part as child to player gameobject
        go.transform.localScale = scale;    // Set scale of this part
        go.transform.localPosition = offset;    //  Set Part position
        part.partPos = go.transform.localPosition;  //  Set part position to equal it's positition in relation to the parent
        Destroy(RobotPartObjectList[pieceNum]); //  Destroy GameObject representation of given part
        RobotPartObjectList[pieceNum] = go;   //  Places game object in list and in the right order
    }

}
