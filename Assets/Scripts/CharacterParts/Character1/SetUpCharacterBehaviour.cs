﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    #region Parts
    public Arm SetArmA;  // Arm 
    public Arm SetArmB;  // Arm 
    public Legs SetLegs;    // Legs scriptable object for character
    public Head SetHead;    // Head scriptable object for character
    public GameObject ArmAttachLeft;    // Gameobject for left arm attachment point
    public GameObject ArmAttachRight;   // Gameobject for right arm attachment point
    public GameObject LegsAttach;   // Attach point for the legs gameobject
    public GameObject HeadAttach;   // Attachpoint for head
    #endregion

    public List<GameObject> RobotPartObjectList;
    public Character CurrentCharacter;  //  Character Scriptable object

    private List<Part> RobotPartList;
    private Quaternion CurrentRotationSet;  //  Setting rotation for parts
    private GameObject PlaceholderGO;
    private Part PlaceHolderP;

    void Start()
    {
        RobotPartObjectList = new List<GameObject>();
        RobotPartList = new List<Part>();
        CurrentRotationSet = new Quaternion(0, 0, 0, 0);    //  For setting rotation of parts

        //  *
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

        GetPart(SetHead, SetHead.prefab, Vector3.one, Vector3.zero, HeadAttach.transform.position, SetHead.partType);
        GetPart(SetArmA, SetArmA.prefab, Vector3.one, Vector3.zero, ArmAttachLeft.transform.position, SetArmA.partType);
        GetPart(SetLegs, SetLegs.prefab, Vector3.one, Vector3.zero, LegsAttach.transform.position, SetLegs.partType);
        GetPart(SetArmB, SetArmB.prefab, Vector3.one, Vector3.zero, ArmAttachRight.transform.position, SetArmB.partType);

        CheckParts();
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
    public void GetPart(Part part, GameObject partObject, Vector3 scale, Vector3 rotation, Vector3 offset, RobotParts piece)
    {
        int pieceNum = (int)piece;       //  get int value from given enum
        var go = Instantiate(partObject);  //  Instantiates arm gameobject as assigned prefab
        go.transform.SetParent(transform);  //  Set part as child to player gameobject
        go.transform.localScale = scale;
        CurrentRotationSet.eulerAngles = rotation;
        go.transform.rotation = CurrentRotationSet; //  Setting rotation
        go.transform.position = offset; //  Set Part position
        part.partPos = go.transform.position;
        Destroy(RobotPartObjectList[pieceNum]);
        RobotPartObjectList[pieceNum] = go;   //  Places game object in list and in the right order
        RobotPartList[pieceNum] = part;
    }


    //  Checks parts to make sure they are in the correct order
    public void CheckParts()
    {
        bool check = false;
        int size = 0;
        Vector3 partPos = Vector3.zero;

        // Checks if parts are in the correct position
        for (int i = 0; i < RobotPartList.Count; i++)
        {
            if (RobotPartList.Count == RobotPartObjectList.Count &&
                RobotPartList[0].partType == RobotParts.HEAD && RobotPartList[1].partType == RobotParts.LEFTARM &&
                RobotPartList[2].partType == RobotParts.LEGS && RobotPartList[3].partType == RobotParts.RIGHTARM)
            {
                check = true;
                size = RobotPartObjectList.Count;
            }
            else
            {
                Destroy(RobotPartObjectList[i]);
                Debug.Log("This part is in the wrong order: " + RobotPartList[i]);
                check = false;
                return;
            }
        }

        //  Replace parts if they are in the correct position
        for (int j = 0; j < size; j++)
        {
            if (check == true)
            {
                partPos = RobotPartList[j].partPos;
                Destroy(RobotPartObjectList[j]);
                GetPart(RobotPartList[j], RobotPartList[j].prefab, Vector3.one, Vector3.zero, partPos, RobotPartList[j].partType);
            }
            else
                return;
        }

    }

    
}
