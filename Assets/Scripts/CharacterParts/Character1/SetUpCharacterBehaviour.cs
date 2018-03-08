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

    public List<GameObject> OrderList;
    private Quaternion CurrentRotationSet;  //  Setting rotation for parts
    private GameObject PlaceholderGO;

    void Start()
    {
        RobotPartList = new List<GameObject>();
        OrderList = new List<GameObject>();
        CurrentRotationSet = new Quaternion(0, 0, 0, 0);    //  For setting rotation of parts

        //  *
        for (int i = 0; i < 4; i++)
        {
            RobotPartList.Add(PlaceholderGO);
            OrderList.Add(PlaceholderGO);
            Destroy(RobotPartList[i]);
            Destroy(OrderList[i]);
        }

        HeadAttach = SetupAttachPoints(Vector3.up);
        LegsAttach = SetupAttachPoints(Vector3.down);
        ArmAttachLeft = SetupAttachPoints(Vector3.left);
        ArmAttachRight = SetupAttachPoints(Vector3.right);

        PositionPart(SetArmA.prefab, Vector3.one, Vector3.zero, ArmAttachLeft.transform.position, SetArmA.partType);
        PositionPart(SetArmB.prefab, Vector3.one, Vector3.zero, ArmAttachRight.transform.position, SetArmB.partType);
        PositionPart(SetLegs.prefab, Vector3.one, Vector3.zero, LegsAttach.transform.position, SetLegs.partType);
        PositionPart(SetHead.prefab, Vector3.one, Vector3.zero, HeadAttach.transform.position, SetHead.partType);

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
    public void PositionPart(GameObject part, Vector3 scale, Vector3 rotation, Vector3 offset, RobotParts piece)
    {
        int pieceNum = (int)piece;       //  get int value from given enum
        var go = part;  //  Instantiates arm gameobject as assigned prefab
        go.transform.SetParent(transform);  //  Set part as child to player gameobject
        go.transform.localScale = scale;
        CurrentRotationSet.eulerAngles = rotation;
        go.transform.rotation = CurrentRotationSet; //  Setting rotation
        go.transform.position = offset; //  Set Part position
        Destroy(RobotPartList[pieceNum]);
        RobotPartList[pieceNum] = go;   //  Places game object in list and in the right order

        for (int i = 0; i < RobotPartList.Count; i++)
        {
            if (pieceNum == i)
                OrderList[i] = RobotPartList[i];
        }
    }

    //  ***
    //  Check order of parts and then instantiate parts
    public void GetPartOrder()
    {
        // Clear Body Part List
        for (int i = 0; i < RobotPartList.Count; i++)
        {
            Destroy(RobotPartList[i]);
        }

        for (int j = 0; j < OrderList.Count; j++)
        {
            if (j != (int) RobotParts.HEAD || j != (int) RobotParts.LEFTARM ||
                j != (int) RobotParts.LEGS || j != (int) RobotParts.RIGHTARM)
            {
                Debug.Log("Body part in wrong order!");
                break;
            }

            if (j == (int)RobotParts.HEAD || j == (int)RobotParts.LEFTARM ||
                j == (int)RobotParts.LEGS || j == (int)RobotParts.RIGHTARM)
            {
                RobotPartList[j] = OrderList[j];
            }

            Instantiate(RobotPartList[j]);
        }

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
