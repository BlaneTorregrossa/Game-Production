using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  build the parts in the robot space. 
//  Take the character scriptable and build the robot by referencing the individual objects.

public class SetUpCharacterBehaviour : MonoBehaviour
{
    //  For setting how part gameObjects are brought into the scene. order should be (going clockwise):
    //  HEAD, LEFTARM, LEGS, RIGHTARM
    public enum RobotParts
    {
        HEAD = 0,
        LEFTARM = 1,
        LEGS = 2,
        RIGHTARM = 3
    }

    #region Parts
    public Arm SetArmLeft;  // Arm 
    public Arm SetArmRight;  // Arm 
    public Legs SetLegs;    // Legs scriptable object for character
    public Head SetHead;    // Head scriptable object for character
    public GameObject ArmAttachLeft;    // Gameobject for left arm attachment point
    public GameObject ArmAttachRight;   // Gameobject for right arm attachment point
    public GameObject LegsAttach;   // Attach point for the legs gameobject
    public GameObject HeadAttach;   // Attachpoint for head
    #endregion
    public List<Part> RobotPartList;
    public List<GameObject> RobotPartObjectList;
    public Character CurrentCharacter;  //  Character Scriptable object

    private Quaternion CurrentRotationSet;  //  Setting rotation for parts
    private GameObject PlaceholderGO;
    private Part PlaceHolderP;

    void Start()
    {
        RobotPartObjectList = new List<GameObject>();
        RobotPartList = new List<Part>();
        CurrentRotationSet = new Quaternion(0, 0, 0, 0);    //  For setting rotation of parts
        CurrentCharacter.Health = 100;  //  Set Health for "Character"

        for (int i = 0; i < 4; i++)
        {
            RobotPartObjectList.Add(PlaceholderGO);
            RobotPartList.Add(PlaceHolderP);
            Destroy(RobotPartObjectList[i]);
            Destroy(RobotPartList[i]);
        }

        HeadAttach = SetupAttachPoints(Vector3.up);
        LegsAttach = SetupAttachPoints(Vector3.down);
        ArmAttachLeft = SetupAttachPoints(Vector3.left);
        ArmAttachRight = SetupAttachPoints(Vector3.right);

        //Parts for the start of the scene
        GetPart(SetHead, SetHead.prefab, Vector3.one, Vector3.zero, HeadAttach.transform.localPosition, SetHead.partType);
        GetPart(SetArmLeft, SetArmLeft.prefab, Vector3.one, Vector3.zero, ArmAttachLeft.transform.localPosition, SetArmLeft.partType);
        GetPart(SetLegs, SetLegs.prefab, Vector3.one, Vector3.zero, LegsAttach.transform.localPosition, SetLegs.partType);
        GetPart(SetArmRight, SetArmRight.prefab, Vector3.one, Vector3.zero, ArmAttachRight.transform.localPosition, SetArmRight.partType);
    }

    // Expected points for the parts to be placed
    public GameObject SetupAttachPoints(Vector3 offset)
    {
        var quarterScale = new Vector3(.25f, .25f, .25f);   //  Setting scale of the attach point
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);    //  GameObject representation of point
        go.transform.localScale = quarterScale; //  Assigning sacle of the attach point
        go.transform.SetParent(transform);  //  Sets attach point's parent
        go.transform.localPosition = offset;    //  Set offset of attachpoint in relation to it's parent
        Destroy(go.GetComponent<BoxCollider>());    //  Removes box collider
        return go;  //  Returns go
    }

    //  Position parts based on the part given
    public void GetPart(Part part, GameObject partObject, Vector3 scale, Vector3 rotation, Vector3 offset, RobotParts piece)
    {
        int pieceNum = (int)piece;  //  get int value from given enum
        var go = Instantiate(partObject);  //  Instantiates arm gameobject as assigned prefab
        go.transform.SetParent(transform);  //  Set part as child to player gameobject
        go.transform.localScale = scale;    // Set scale of this part
        CurrentRotationSet.eulerAngles = rotation;  //  Sets vector3 rotation
        go.transform.rotation = CurrentRotationSet; //  Setting rotation for part
        go.transform.localPosition = offset;    //  Set Part position
        part.partPos = go.transform.localPosition;  //  Set part position to equal it's positition in relation to the parent
        Destroy(RobotPartObjectList[pieceNum]); //  Destroy GameObject representation of given part
        RobotPartObjectList[pieceNum] = go;   //  Places game object in list and in the right order
        RobotPartList[pieceNum] = part; //  Sets part in given position on the list
    }

}
