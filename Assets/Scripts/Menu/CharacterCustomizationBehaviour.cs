using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCustomizationBehaviour : MonoBehaviour
{
    [HideInInspector]
    public SetUpCharacterBehaviour SetupInstance;    //  Instance of character setup
    //  Text objects for updating menu information
    #region TextBoxes
    [HideInInspector]
    public Text CurrentLeftArmText;     //  Text Box naming selected left arm PartName
    [HideInInspector]
    public Text CurrentRightArmText;    //  Text Box naming selected right arm PartName
    [HideInInspector]
    public Text CurrentLegsText;    //  Text Box naming selected legs PartName
    [HideInInspector]
    public Text CurrentHeadText;    //  Text Box naming selected head PartNam
    [HideInInspector]
    public Text PartDescriptionText;    //  Updationg part description to read most recently changed parts description
    #endregion
    #region UnlockedLists
    public List<Arm> UnlockedLeftArms;  //  List of leftArm objects
    public List<Arm> UnlockedRightArms; //  List of RightArm objects
    public List<Legs> UnlockedLegs; //  List of Legs objects
    public List<Head> UnlockedHeads;    // List of Head objects
    #endregion
    public Character CustomizedCharacter;   //  Character scriptableobject from which part information is pulled from

    private bool AttachSet; //  Check for if attach points have already been set
    #region ListCount
    private int LeftArmNum; //  Interger for used index of the UnlockedLeftArms list
    private int RightArmNum;    //  Interger for used index of the UnlockedRightArms list
    private int LegsNum;    //  Interger for used index of the UnlockedLegs list
    private int HeadNum;    //  Interger for used index of the UnlcokedHeads list
    #endregion

    void Start()
    {
        SetupInstance = transform.gameObject.GetComponent<SetUpCharacterBehaviour>();  // getting component for character set up

        #region SortingTroughLists
        LeftArmNum = 0; // Starting index for list 
        RightArmNum = 0;    // Starting index for list
        LegsNum = 0;    // Starting index for list
        HeadNum = 0;    // Starting index for list
        #endregion

        SetParts(); //  Assigning parts for character object to change player gameobject

        #region StartText
        PartDescriptionText.text = "SELECT YOUR CHARACTER PARTS!";  //  Default Description text
        CurrentHeadText.text = SetupInstance.CurrentCharacter.HeadPiece.partName;  //  Displays PartName of selected Head Object
        CurrentLeftArmText.text = SetupInstance.CurrentCharacter.Left.partName;    //  Displays PartName of selected LeftArm Object
        CurrentLegsText.text = SetupInstance.CurrentCharacter.LegSet.partName;  //  Displays PartName of selected Legs Object
        CurrentRightArmText.text = SetupInstance.CurrentCharacter.Right.partName;  //  Displays PartName of selected RightArm Object
        #endregion
    }

    public void SetParts()  //  Set Parts on character object based off current index of list
    {
        CustomizedCharacter.Left = UnlockedLeftArms[LeftArmNum];    //  Sets selected part to be the same part of current index of the LeftArm list
        CustomizedCharacter.Right = UnlockedRightArms[RightArmNum]; //  Sets selected part to be the same part of current index of the RightArm list
        CustomizedCharacter.LegSet = UnlockedLegs[LegsNum]; //  Sets selected part to be the same part of current index of the Legs list
        CustomizedCharacter.HeadPiece = UnlockedHeads[HeadNum]; //  Sets selected part to be the same part of current index of the Heads list
        CustomizedCharacter.parts = new List<Part>() {       // List of Parts (LeftArm, RightArm, LegSet, HeadPiece) Order brought into scene     
            CustomizedCharacter.Left,  //  0
            CustomizedCharacter.Right,  //  1
            CustomizedCharacter.HeadPiece,   //  2
            CustomizedCharacter.LegSet, //  3
        };

        if (AttachSet == false) //  If false, attach points are added to the character gameObject
        {
            SetupInstance.HeadAttach = SetupInstance.SetupAttachPoints(Vector3.up); //  Set up attach points for instantiated prefabs (Head)
            SetupInstance.LegsAttach = SetupInstance.SetupAttachPoints(Vector3.down); //  Set up attach points for instantiated prefabs (Legs)
            SetupInstance.ArmAttachLeft = SetupInstance.SetupAttachPoints(Vector3.left); //  Set up attach points for instantiated prefabs (Left Arm)
            SetupInstance.ArmAttachRight = SetupInstance.SetupAttachPoints(Vector3.right); //  Set up attach points for instantiated prefabs (Right Arm)
            AttachSet = true;   // To prevent attach points from being added again unless the scenes switch
        }

        SetupInstance.CurrentCharacter = CustomizedCharacter;   //  Applies changes in setup

        //  Note: I Found that one list of objects aren't organized correctlly, but the gameobject list is organized in the right order
        for (int i = 0; i < SetupInstance.CurrentCharacter.parts.Count; i++)    //  Brings given parts into scene based on the character part list. Trying to get this to check order.
        {


            if (SetupInstance.CurrentCharacter.parts[i].partType == SetUpCharacterBehaviour.RobotParts.HEAD)    //  0
            {
                SetupInstance.GetPart(SetupInstance.CurrentCharacter.parts[i],  //  Current Part
                    SetupInstance.CurrentCharacter.parts[i].prefab, //  Prefab assigned to Current Part
                    Vector3.one, SetupInstance.HeadAttach.transform.localPosition,  //  Scale and offset
                    SetupInstance.CurrentCharacter.parts[i].partType);  //  Part Type
            }
            else if (SetupInstance.CurrentCharacter.parts[i].partType == SetUpCharacterBehaviour.RobotParts.LEFTARM)    //  1
            {
                SetupInstance.GetPart(SetupInstance.CurrentCharacter.parts[i],  //  Current Part
                    SetupInstance.CurrentCharacter.parts[i].prefab, //  Prefab assigned to Current Part
                    Vector3.one, SetupInstance.ArmAttachLeft.transform.localPosition, //  Scale and offse
                    SetupInstance.CurrentCharacter.parts[i].partType);  //  Part Type
            }
            else if (SetupInstance.CurrentCharacter.parts[i].partType == SetUpCharacterBehaviour.RobotParts.LEGS)   //  2
            {
                SetupInstance.GetPart(SetupInstance.CurrentCharacter.parts[i],  //  Current Part
                    SetupInstance.CurrentCharacter.parts[i].prefab, //  Prefab assigned to Current Part
                    Vector3.one, SetupInstance.LegsAttach.transform.localPosition,  //  Scale and offse
                    SetupInstance.CurrentCharacter.parts[i].partType);  //  Part Type
            }
            else if (SetupInstance.CurrentCharacter.parts[i].partType == SetUpCharacterBehaviour.RobotParts.RIGHTARM)   //  3
            {
                SetupInstance.GetPart(SetupInstance.CurrentCharacter.parts[i],  //  Current Part
                    SetupInstance.CurrentCharacter.parts[i].prefab, //  Prefab assigned to Current Part
                    Vector3.one, SetupInstance.ArmAttachRight.transform.localPosition,  //  Scale and offse
                    SetupInstance.CurrentCharacter.parts[i].partType);  //  Part Type
            }

            else // If a known part type is not given
            {
                Debug.Log("Part of unkown type or in wrong position in Character parts list: " + SetupInstance.CurrentCharacter.parts[i]);
                break;
            }
        }
    }

    //  Buttons for switching parts + changing description
    #region Buttons
    public void NextHead()
    {
        if (HeadNum < UnlockedHeads.Count - 1)
        {
            HeadNum++;  //  Increases Head List index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedHeads[HeadNum].description;  //  Update Part Description
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName; //  Update Part Name
    }   //  Move index forwards in UnlockedHeadsList

    public void PrevHead()
    {
        if (HeadNum > 0)
        {
            HeadNum--;  //  Increases Head List index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedHeads[HeadNum].description;  //  Update Part Description
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName; //  Update Part Name
    }   //  Move index backwards in UnlockedHeadsList

    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedLeftArms.Count - 1)
        {
            LeftArmNum++;   //  Increases Left Arm List Index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;    //  Update Part Description
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;    //  Update Part Name
    }   //  Move index forwards in UnlockedLeftArmList

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;   //  Decreases Left Arm List Index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;    //  Update Part Description
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;    //  Update part
    }   //  Move index backwards in UnlockedLeftArmList

    public void NextLegs()
    {
        if (LegsNum < UnlockedLegs.Count - 1)
        {
            LegsNum++;  //  Increases Legs List Index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedLegs[LegsNum].description;   //  Update Part Description
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;  //  Update Part
    }   //  Move index forwards in UnlockedLegsList

    public void PrevLegs()
    {
        if (LegsNum > 0)
        {
            LegsNum--;  //  Decreases Legs List index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedLegs[LegsNum].description;   //  Update Part Description
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;  //  Update Part
    }   //  Move index backwards in UnlockedLegsList

    public void NextRightArm()
    {
        if (RightArmNum < UnlockedRightArms.Count - 1)
        {
            RightArmNum++;  //  Increases Right Arm List index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;  //  Update Part Description
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName; //  Update Part
    }   //  Move index forwards in UnlockedRightArmsList

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;  //  Decreases Right Arm List index count
            SetParts(); //  Update Character
        }

        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;  //  Update Part Description
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName; //  Update Part
    }   //  Move index backwards in UnlockedRightArmsList
    #endregion
}
