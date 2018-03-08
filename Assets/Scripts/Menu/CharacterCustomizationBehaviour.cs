using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizationBehaviour : MonoBehaviour
{
    public enum RobotParts
    {
        HEAD = 0,
        LEFTARM = 1,
        LEFTLEG = 2,
        RIGHTLEG = 3,
        RIGHTARM = 4,
    }

    public static SetUpCharacterBehaviour SetupInstance; // Instance of character setup


    public GameObject CharacterA;       //  GameObject for characterA

    #region Text
    [HideInInspector]
    public Text CurrentLeftArmText;     // Text for Left Arm
    [HideInInspector]
    public Text CurrentRightArmText;
    [HideInInspector]
    public Text CurrentLegsText;
    [HideInInspector]
    public Text CurrentHeadText;
    [HideInInspector]
    public Text PartDescriptionText;    // Descrition of most recent part to be changed
    #endregion

    public Character CustomizedCharacter;   // character scriptableobject from which part information is pulled from

    #region UnlockedLists
    [HideInInspector]
    public List<Arm> UnlockedLeftArms;  // List of left arm objects 
    [HideInInspector]
    public List<Arm> UnlockedRightArms;
    [HideInInspector]
    public List<Legs> UnlockedLegs;
    [HideInInspector]
    public List<Head> UnlockedHeads;
    #endregion

    private int LeftArmNum;
    private int RightArmNum;
    private int LegsNum;
    private int HeadNum;

    void Start()
    {
        SetupInstance = CharacterA.AddComponent<SetUpCharacterBehaviour>();  // adding component for setting up the character

        CustomizedCharacter = new Character // Changing character object name 
        {
            name = "Character A",
            Name = "Character A",
        };

        PartDescriptionText.text = "SELECT YOUR CHARACTER PARTS!";      // Placeholder description
        LeftArmNum = 0; RightArmNum = 0;  LegsNum = 0; HeadNum = 0;
        SetParts(); // Assigning parts for character object
    }

    public void SetParts()
    {
        CustomizedCharacter.Left = UnlockedLeftArms[LeftArmNum];    // Sets selected part to be the current index of list
        CustomizedCharacter.Right = UnlockedRightArms[RightArmNum];
        CustomizedCharacter.LegSet = UnlockedLegs[LegsNum];
        CustomizedCharacter.HeadPiece = UnlockedHeads[HeadNum];
        SetupInstance.CurrentCharacter = CustomizedCharacter;   //  Applies changes in setup

        SetupInstance.SetArmA = UnlockedLeftArms[LeftArmNum];   //  Gives part to setup instance
        SetupInstance.SetArmB = UnlockedRightArms[RightArmNum];
        SetupInstance.SetLegs = UnlockedLegs[LegsNum];
        SetupInstance.SetHead = UnlockedHeads[HeadNum];

    }


    //  *
    //  Buttons for switching parts + changing description
    #region Buttons
    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedLeftArms.Count - 1)
        {
            LeftArmNum++;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetArmA.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.ArmAttachLeft.transform.position, 0);
        }
        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;

    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetArmA.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.ArmAttachLeft.transform.position, 0);
        }
        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;

    }

    public void NextRightArm()
    {
        if (RightArmNum < UnlockedRightArms.Count - 1)
        {
            RightArmNum++;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetArmB.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.ArmAttachRight.transform.position, 1);

        }
        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;

    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetArmB.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.ArmAttachRight.transform.position, 1);

        }
        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;

    }

    public void NextLegs()
    {
        if (LegsNum < UnlockedLegs.Count - 1)
        {
            LegsNum++;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetLegs.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.LegsAttach.transform.position, 2);
        }
        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;

    }

    public void PrevLegs()
    {
        if (LegsNum > 0)
        {
            LegsNum--;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetLegs.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.LegsAttach.transform.position, 2);
        }
        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;

    }

    public void NextHead()
    {
        if (HeadNum < UnlockedHeads.Count - 1)
        {
            HeadNum++;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetHead.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.HeadAttach.transform.position, 3);
        }

        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName;

    }

    public void PrevHead()
    {
        if (HeadNum > 0)
        {
            HeadNum--;
            SetParts();
            SetupInstance.PositionPart(SetupInstance.SetHead.prefab, new Vector3(1, 1, 1), new Vector3(0, 0, 0), SetupInstance.HeadAttach.transform.position, 3);
        }

        SetupInstance.KeepCharacterSetup();
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName;

    }
    #endregion

}
