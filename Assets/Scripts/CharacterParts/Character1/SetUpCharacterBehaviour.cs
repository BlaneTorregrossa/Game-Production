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
    [HideInInspector]
    public Arm SetArmLeft;  // Arm Scriptableobject for character
    [HideInInspector]
    public Arm SetArmRight;  // Arm ScriptableObject for character
    [HideInInspector]
    public Legs SetLegs;    // Legs scriptable object for character
    [HideInInspector]
    public Head SetHead;    // Head scriptable object for character
    [HideInInspector]
    public GameObject ArmAttachLeft;    // Gameobject for left arm attachment point
    [HideInInspector]
    public GameObject ArmAttachRight;   // Gameobject for right arm attachment point
    [HideInInspector]
    public GameObject LegsAttach;   // Attach point for the legs gameobject
    [HideInInspector]
    public GameObject HeadAttach;   // Attachpoint for head
    #endregion
    public List<Part> RobotPartList;    //  List of Parts for the character, Sorted in set order (MAY NEED CHANGES)  ***
    public List<GameObject> RobotPartObjectList;    //  List of GameObjects attached to Character GameObject, Sorted in set order (MAY NEED CHANGE)  ***
    public Character CurrentCharacter;  //  Character Scriptable object

    private Quaternion CurrentRotationSet;  //  Setting rotation for parts and character  (Is this needed?) ***
    private GameObject PlaceholderGO;   //  REMOVE  ***
    private Part PlaceHolderP;  //  REMOVE  ***

    void Start()
    {
        RobotPartObjectList = new List<GameObject>();
        RobotPartList = new List<Part>();
        CurrentRotationSet = new Quaternion(0, 0, 0, 0);    //  For setting rotation of parts
        CurrentCharacter.Health = 100;  //  Set Health for Character
        CurrentCharacter.Name = "P1";  //  Set Name for Character


        for (int i = 0; i < 4; i++) //  REMOVE    ***
        {
            RobotPartObjectList.Add(PlaceholderGO);
            RobotPartList.Add(PlaceHolderP);
            Destroy(RobotPartObjectList[i]);
            Destroy(RobotPartList[i]);
        }

        HeadAttach = SetupAttachPoints(Vector3.up); //  Set up attach points for instantiated prefabs (Head)
        LegsAttach = SetupAttachPoints(Vector3.down); //  Set up attach points for instantiated prefabs (Legs)
        ArmAttachLeft = SetupAttachPoints(Vector3.left); //  Set up attach points for instantiated prefabs (Left Arm)
        ArmAttachRight = SetupAttachPoints(Vector3.right); //  Set up attach points for instantiated prefabs (Right Arm)

        //Parts for the start of the scene
        GetPart(SetHead, SetHead.prefab, Vector3.one, Vector3.zero, HeadAttach.transform.localPosition, SetHead.partType);
        GetPart(SetArmLeft, SetArmLeft.prefab, Vector3.one, Vector3.zero, ArmAttachLeft.transform.localPosition, SetArmLeft.partType);
        GetPart(SetLegs, SetLegs.prefab, Vector3.one, Vector3.zero, LegsAttach.transform.localPosition, SetLegs.partType);
        GetPart(SetArmRight, SetArmRight.prefab, Vector3.one, Vector3.zero, ArmAttachRight.transform.localPosition, SetArmRight.partType);
    }

    // Expected points for the parts to be placed
    public GameObject SetupAttachPoints(Vector3 offset)
    {
        var quarterScale = new Vector3(.1f, .1f, .1f);   //  Setting scale of the attach point
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);    //  GameObject representation of point
        go.name = "Attach Point";   //  To label as attach point in inspector
        go.transform.localScale = quarterScale; //  Assigning sacle of the attach point
        go.transform.SetParent(transform);  //  Sets attach point's parent
        go.transform.localPosition = offset;    //  Set offset of attachpoint in relation to it's parent
        Destroy(go.GetComponent<BoxCollider>());    //  Removes box collider
        return go;  // Return
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
