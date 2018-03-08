using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetUpCharacterBehaviour : MonoBehaviour
{

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


    public Character CurrentCharacter;  // Character Scriptable object
    public List<GameObject> BodyPartList = new List<GameObject>();  // List of bodypart gameobjects used for the character

    public GameObject SavedCharacterBody = null;   // Prefab to be saved once character is selected 

    private Quaternion CurrentRotationSet;
    private GameObject Blank;

    void Start()
    {
        CurrentRotationSet = new Quaternion(0, 0, 0, 0); // For setting rotation of part gameobjects

        //  *
        for (int b = 0; b < 4; b++)
            BodyPartList.Add(Blank);

        //  *
        for (int t = 0; t < 4; t++)
            Destroy(BodyPartList[t]);


        HeadAttach = SetupAttachPoints(Vector3.up);
        LegsAttach = SetupAttachPoints(Vector3.down);
        ArmAttachLeft = SetupAttachPoints(Vector3.left);
        ArmAttachRight = SetupAttachPoints(Vector3.right);

        PositionPart(SetArmA.prefab, Vector3.one, Vector3.zero, ArmAttachLeft.transform.position, 0);
        PositionPart(SetArmB.prefab, Vector3.one, Vector3.zero, ArmAttachRight.transform.position, 1);
        PositionPart(SetLegs.prefab, Vector3.one, Vector3.zero, LegsAttach.transform.position, 2);
        PositionPart(SetHead.prefab, Vector3.one, Vector3.zero, HeadAttach.transform.position, 3);

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

    // Position arms based on Arm objects given
    public GameObject PositionPart(GameObject part, Vector3 scale, Vector3 rotation, Vector3 offset, int partindex)
    {
        GameObject go = null;

        go = Instantiate(part); // Instantiates arm gameobject as assigned prefab
        go.transform.SetParent(transform);   // Set part as child to player gameobject
        go.transform.localScale = scale;
        CurrentRotationSet.eulerAngles = rotation;
        go.transform.rotation = CurrentRotationSet;  // Setting rotation
        go.transform.position = offset;    // Set Part position
        if (BodyPartList[partindex] != null)
        {
            Destroy(BodyPartList[partindex]);
            BodyPartList[partindex] = go;
        }
        else
            BodyPartList[partindex] = go;

        return go;
    }

    // Saving character as a prefab
    public void KeepCharacterSetup()
    {
        // Saves Character Object as a prefab
        SavedCharacterBody = PrefabUtility.CreatePrefab(
            "Assets/Prefabs/SavedCharacters/CharacterA.prefab",
            gameObject);
    }
}
