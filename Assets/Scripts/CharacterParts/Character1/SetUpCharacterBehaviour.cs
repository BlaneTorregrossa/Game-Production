using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetUpCharacterBehaviour : MonoBehaviour
{
    //  For setting how part gameObject are brought into scene order should be (going clockwise):
    //  HEAD, LEFTARM, LEGS, RIGHTARM, HEAD, LEFTARM, ETC.
    public enum RobotParts
    {
        HEAD = 0,
        LEFTARM = 1,
        LEGS = 2,
        RIGHTARM = 3
    }

    #region Arms
    public Arm SetArmA;  // Arm 
    public Arm SetArmB;  // Arm 
    public GameObject ArmAttachLeft;    // Gameobject for left arm attachment point
    public GameObject ArmAttachRight;   // Gameobject for right arm attachment point
    #endregion
    #region Legs
    public Legs SetLegs;    // Legs scriptable object for character
    public GameObject LegsAttach;   // Attach point for the legs gameobject
    #endregion
    #region Head
    public Head SetHead;    // Head scriptable object for character
    public GameObject HeadAttach;   // Attachpoint for head
    #endregion

    [HideInInspector]
    public List<GameObject> RobotPartList;
    public Character CurrentCharacter;  //  Character Scriptable object
    public GameObject SavedCharacterBody;   //  Prefab to be saved once character is selected 

    private Quaternion CurrentRotationSet;  //  Setting rotation for parts
    private GameObject PlaceholderGO;

    void Start()
    {
        RobotPartList = new List<GameObject>();
        CurrentRotationSet = new Quaternion(0, 0, 0, 0);    //  For setting rotation of parts

        //  *
        for (int i = 0; i < 4; i++)
        {
            RobotPartList.Add(PlaceholderGO);
            Destroy(RobotPartList[i]);
        }

        HeadAttach = SetupAttachPoints(Vector3.up);
        LegsAttach = SetupAttachPoints(Vector3.down);
        ArmAttachLeft = SetupAttachPoints(Vector3.left);
        ArmAttachRight = SetupAttachPoints(Vector3.right);

        GetPart(SetHead.prefab, Vector3.one, Vector3.zero, HeadAttach.transform.position, SetHead.partType);
        GetPart(SetLegs.prefab, Vector3.one, Vector3.zero, LegsAttach.transform.position, SetLegs.partType);
        GetPart(SetArmA.prefab, Vector3.one, Vector3.zero, ArmAttachLeft.transform.position, SetArmA.partType);
        GetPart(SetArmB.prefab, Vector3.one, Vector3.zero, ArmAttachRight.transform.position, SetArmB.partType);

        KeepCharacterSetup();
    }

    public GameObject SetupAttachPoints(Vector3 offset)
    {
        var quarterScale = new Vector3(.25f, .25f, .25f);
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localScale = quarterScale;
        go.transform.SetParent(transform);
        go.transform.localPosition = offset;
        Destroy(go.GetComponent<BoxCollider>());
        return go;
    }

    //  ***
    //  Position arms based on Arm objects given
    public void GetPart(GameObject part, Vector3 scale, Vector3 rotation, Vector3 offset, RobotParts piece)
    {
        int pieceNum = (int)piece;       //  get int value from given enum
        var go = Instantiate(part);  //  Instantiates arm gameobject as assigned prefab
        go.transform.SetParent(transform);  //  Set part as child to player gameobject
        go.transform.localScale = scale;
        CurrentRotationSet.eulerAngles = rotation;
        go.transform.rotation = CurrentRotationSet; //  Setting rotation
        go.transform.position = offset; //  Set Part position
        Destroy(RobotPartList[pieceNum]);
        RobotPartList[pieceNum] = go;   //  Places game object in list and in the right order
    }

    //  Saving character as a prefab
    public void KeepCharacterSetup()
    {
        //  Saves Character Object as a prefab
        SavedCharacterBody = PrefabUtility.CreatePrefab(
            "Assets/Prefabs/SavedCharacters/CharacterA.prefab",
            gameObject);
    }
}
