using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  build the parts in the robot space. 
//  Take the character scriptable and build the robot by referencing the individual objects.

public class CharacterCustomizationBehaviour : MonoBehaviour
{
    public static SetUpCharacterBehaviour SetupInstance;    //  Instance of character setup

    //  Text objects for updating menu information
    #region TextBoxes
    [HideInInspector] public Text CurrentLeftArmText;     // Text for Left Arm
    [HideInInspector] public Text CurrentRightArmText;
    [HideInInspector] public Text CurrentLegsText;
    [HideInInspector] public Text CurrentHeadText;
    [HideInInspector] public Text PartDescriptionText;    // Descrition of most recent part to be changed
    #endregion
    public Character CustomizedCharacter;   //  character scriptableobject from which part information is pulled from
    #region UnlockedLists
    public List<Arm> UnlockedLeftArms;  // List of left arm objects 
    public List<Arm> UnlockedRightArms;
    public List<Legs> UnlockedLegs;
    public List<Head> UnlockedHeads;
    #endregion

    private int LeftArmNum;
    private int RightArmNum;
    private int LegsNum;
    private int HeadNum;

    void Start()
    {
        SetupInstance = transform.gameObject.AddComponent<SetUpCharacterBehaviour>();  // adding component for setting up the character

        CustomizedCharacter = new Character // Changing character object name 
        {
            name = "Character A",
            Name = "Character A",
        };

        LeftArmNum = 0;
        RightArmNum = 0;
        LegsNum = 0;
        HeadNum = 0;
        SetParts(); //  Assigning parts for character object

        #region StartText
        PartDescriptionText.text = "SELECT YOUR CHARACTER PARTS!";
        CurrentHeadText.text = SetupInstance.SetHead.partName;
        CurrentLeftArmText.text = SetupInstance.SetArmA.partName;
        CurrentLegsText.text = SetupInstance.SetLegs.partName;
        CurrentRightArmText.text = SetupInstance.SetArmB.partName;
        #endregion
    }

    public void SetParts()
    {
        CustomizedCharacter.Left = UnlockedLeftArms[LeftArmNum];    //  Sets selected part to be the current index of list
        CustomizedCharacter.Right = UnlockedRightArms[RightArmNum];
        CustomizedCharacter.LegSet = UnlockedLegs[LegsNum];
        CustomizedCharacter.HeadPiece = UnlockedHeads[HeadNum];
        SetupInstance.CurrentCharacter = CustomizedCharacter;   //  Applies changes in setup

        SetupInstance.SetArmA = UnlockedLeftArms[LeftArmNum];   //  Gives part to setup instance
        SetupInstance.SetArmB = UnlockedRightArms[RightArmNum];
        SetupInstance.SetLegs = UnlockedLegs[LegsNum];
        SetupInstance.SetHead = UnlockedHeads[HeadNum];
    }

    //  Buttons for switching parts + changing description
    #region Buttons
    public void NextHead()
    {
        if (HeadNum < UnlockedHeads.Count - 1)
        {
            HeadNum++;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetHead, SetupInstance.SetHead.prefab, Vector3.one, Vector3.zero,
                SetupInstance.HeadAttach.transform.localPosition, SetUpCharacterBehaviour.RobotParts.HEAD);
        }
        
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName;
        SetupInstance.CheckParts();
    }

    public void PrevHead()
    {
        if (HeadNum > 0)
        {
            HeadNum--;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetHead, SetupInstance.SetHead.prefab, Vector3.one, Vector3.zero,
                SetupInstance.HeadAttach.transform.localPosition, SetUpCharacterBehaviour.RobotParts.HEAD);
        }
        
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName;
        SetupInstance.CheckParts();
    }

    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedLeftArms.Count - 1)
        {
            LeftArmNum++;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmA, SetupInstance.SetArmA.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachLeft.transform.localPosition, SetUpCharacterBehaviour.RobotParts.LEFTARM);
        }
        
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;
        SetupInstance.CheckParts();
    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmA ,SetupInstance.SetArmA.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachLeft.transform.localPosition, SetUpCharacterBehaviour.RobotParts.LEFTARM);
        }
        
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;
        SetupInstance.CheckParts();
    }

    public void NextLegs()
    {
        if (LegsNum < UnlockedLegs.Count - 1)
        {
            LegsNum++;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetLegs, SetupInstance.SetLegs.prefab, Vector3.one, Vector3.zero,
                SetupInstance.LegsAttach.transform.localPosition, SetUpCharacterBehaviour.RobotParts.LEGS);
        }
        
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;
        SetupInstance.CheckParts();
    }

    public void PrevLegs()
    {
        if (LegsNum > 0)
        {
            LegsNum--;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetLegs, SetupInstance.SetLegs.prefab, Vector3.one, Vector3.zero,
                SetupInstance.LegsAttach.transform.localPosition, SetUpCharacterBehaviour.RobotParts.LEGS);
        }
        
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;
        SetupInstance.CheckParts();
    }
    public void NextRightArm()
    {
        if (RightArmNum < UnlockedRightArms.Count - 1)
        {
            RightArmNum++;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmB, SetupInstance.SetArmB.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachRight.transform.localPosition, SetUpCharacterBehaviour.RobotParts.RIGHTARM);
        }
        
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;
        SetupInstance.CheckParts();
    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmB, SetupInstance.SetArmB.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachRight.transform.localPosition, SetUpCharacterBehaviour.RobotParts.RIGHTARM);
        }
        
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;
        SetupInstance.CheckParts();
    }

    //  ***
    // For bringing the character given to the "target range" area
    public void BringToTargetRange()
    {

    }
    #endregion
}
