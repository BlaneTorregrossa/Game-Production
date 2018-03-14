using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//  build the parts in the robot space. 
//  Take the character scriptable and build the robot by referencing the individual objects.

public class CharacterCustomizationBehaviour : MonoBehaviour
{
    public static SetUpCharacterBehaviour SetupInstance;    //  Instance of character setup

    //  Text objects for updating menu information
    #region TextBoxes
    [HideInInspector]
    public Text CurrentLeftArmText;
    [HideInInspector]
    public Text CurrentRightArmText;
    [HideInInspector]
    public Text CurrentLegsText;
    [HideInInspector]
    public Text CurrentHeadText;
    [HideInInspector]
    public Text PartDescriptionText;
    #endregion
    #region UnlockedLists
    public List<Arm> UnlockedLeftArms;  //  List of leftArm objects
    public List<Arm> UnlockedRightArms; //  List of RightArm objects
    public List<Legs> UnlockedLegs; //  List of Legs objects
    public List<Head> UnlockedHeads;    // List of Head objects
    #endregion
    public Character CustomizedCharacter;   //  character scriptableobject from which part information is pulled from

    #region ListCount
    private int LeftArmNum;
    private int RightArmNum;
    private int LegsNum;
    private int HeadNum;
    #endregion

    void Start()
    {
        SetupInstance = transform.gameObject.AddComponent<SetUpCharacterBehaviour>();  // adding component for setting up the character
        
        #region Character
        CustomizedCharacter = ScriptableObject.CreateInstance<Character>(); // Changing character object name 
        CustomizedCharacter.name = "Character A";   //  Object Name
        CustomizedCharacter.Name = "Character A";   //  Object variable for Name
        #endregion

        #region SortingTroughLists
        LeftArmNum = 0;
        RightArmNum = 0;
        LegsNum = 0;
        HeadNum = 0;
        #endregion

        SetParts(); //  Assigning parts for character object

        #region StartText
        PartDescriptionText.text = "SELECT YOUR CHARACTER PARTS!";
        CurrentHeadText.text = SetupInstance.SetHead.partName;
        CurrentLeftArmText.text = SetupInstance.SetArmLeft.partName;
        CurrentLegsText.text = SetupInstance.SetLegs.partName;
        CurrentRightArmText.text = SetupInstance.SetArmRight.partName;
        #endregion
    }

    public void SetParts()  //  Set Parts on character object based off current index of list
    {
        CustomizedCharacter.Left = UnlockedLeftArms[LeftArmNum];    //  Sets selected part to be the same part of current index of list
        CustomizedCharacter.Right = UnlockedRightArms[RightArmNum]; //  Sets selected part to be the same part of current index of list
        CustomizedCharacter.LegSet = UnlockedLegs[LegsNum]; //  Sets selected part to be the same part of current index of list
        CustomizedCharacter.HeadPiece = UnlockedHeads[HeadNum]; //  Sets selected part to be the same part of current index of list
        SetupInstance.CurrentCharacter = CustomizedCharacter;   //  Applies changes in setup

        SetupInstance.SetArmLeft = UnlockedLeftArms[LeftArmNum];   //  Gives selected part to setup instance
        SetupInstance.SetArmRight = UnlockedRightArms[RightArmNum];     //  Gives selected part to setup instance
        SetupInstance.SetLegs = UnlockedLegs[LegsNum];  //  Gives selected part to setup instance
        SetupInstance.SetHead = UnlockedHeads[HeadNum]; //  Gives selected part to setup instance
    }

    // After new changes this function might be useless ***
    // Current Issues: Repeating (sort of), Needs to be shorter ***
    // For saving parts as Scriptable Objects to be used in a new scene
    public void SaveParts(List<Part> currentParts)
    {
        for (int i = 0; i < currentParts.Count; i++)
        {
            Part selectedPart = currentParts[i];

            // Shorten This ***
            if (selectedPart.partType == SetUpCharacterBehaviour.RobotParts.HEAD)
            {
                var selectedHead = ScriptableObject.CreateInstance<Head>();
                selectedHead.partName = SetupInstance.SetHead.partName; //  keep?
                selectedHead.description = SetupInstance.SetHead.description;   //  keep?
                selectedHead.partPos = SetupInstance.SetHead.partPos;   //  keep?
                selectedHead.partType = SetupInstance.SetHead.partType;
                selectedHead.prefab = SetupInstance.SetHead.prefab;
                selectedHead.name = "Saved Head";

                SetupInstance.RobotPartList[i] = selectedHead;
            }

            // Shorten this ***
            else if (selectedPart.partType == SetUpCharacterBehaviour.RobotParts.LEFTARM)
            {
                var selectedLeft = ScriptableObject.CreateInstance<Arm>();
                selectedLeft.partName = SetupInstance.SetArmLeft.partName;  //  keep?
                selectedLeft.description = SetupInstance.SetArmLeft.description;    //  keep?
                selectedLeft.partPos = SetupInstance.SetArmLeft.partPos;    //  keep?
                selectedLeft.partType = SetupInstance.SetArmLeft.partType;
                selectedLeft.prefab = SetupInstance.SetArmLeft.prefab;
                selectedLeft.isLeft = true;
                selectedLeft.isRight = false;
                selectedLeft.isMelee = SetupInstance.SetArmLeft.isMelee;
                selectedLeft.isRanged = SetupInstance.SetArmLeft.isRanged;
                selectedLeft.meleeAttackSpeed = SetupInstance.SetArmLeft.meleeAttackSpeed;
                selectedLeft.meleeDamage = SetupInstance.SetArmLeft.meleeDamage;
                selectedLeft.projectileDamage = SetupInstance.SetArmLeft.projectileDamage;
                selectedLeft.projectileSpeed = SetupInstance.SetArmLeft.projectileSpeed;
                selectedLeft.name = "Saved Left Arm";

                SetupInstance.RobotPartList[i] = selectedLeft;
            }

            // Shorten This ***
            else if (selectedPart.partType == SetUpCharacterBehaviour.RobotParts.LEGS)
            {
                var selectedLegs = ScriptableObject.CreateInstance<Legs>();
                selectedLegs.partName = SetupInstance.SetLegs.partName; //  keep?
                selectedLegs.description = SetupInstance.SetLegs.description;   //  keep?
                selectedLegs.partPos = SetupInstance.SetLegs.partPos;   //  keep?
                selectedLegs.partType = SetupInstance.SetLegs.partType;
                selectedLegs.prefab = SetupInstance.SetLegs.prefab;
                selectedLegs.DashCharges = SetupInstance.SetLegs.DashCharges;
                selectedLegs.DashSpeed = SetupInstance.SetLegs.DashSpeed;
                selectedLegs.Speed = SetupInstance.SetLegs.Speed;
                selectedLegs.name = "Saved Legs";

                SetupInstance.RobotPartList[i] = selectedLegs;
            }

            // Shorten This ***
            else if (selectedPart.partType == SetUpCharacterBehaviour.RobotParts.RIGHTARM)
            {
                var selectedRight = ScriptableObject.CreateInstance<Arm>();
                selectedRight.partName = SetupInstance.SetArmRight.partName;    //  keep?
                selectedRight.description = SetupInstance.SetArmRight.description;  //  keep?
                selectedRight.partPos = SetupInstance.SetArmRight.partPos;  //  keep?
                selectedRight.partType = SetupInstance.SetArmRight.partType;
                selectedRight.prefab = SetupInstance.SetArmRight.prefab;
                selectedRight.isLeft = false;
                selectedRight.isRight = true;
                selectedRight.isMelee = SetupInstance.SetArmRight.isMelee;
                selectedRight.isRanged = SetupInstance.SetArmRight.isRanged;
                selectedRight.meleeAttackSpeed = SetupInstance.SetArmRight.meleeAttackSpeed;
                selectedRight.meleeDamage = SetupInstance.SetArmRight.meleeDamage;
                selectedRight.projectileDamage = SetupInstance.SetArmRight.projectileDamage;
                selectedRight.projectileSpeed = SetupInstance.SetArmRight.projectileSpeed;
                selectedRight.name = "Saved Right Arm";

                SetupInstance.RobotPartList[i] = selectedRight;
            }

        }
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
    }

    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedLeftArms.Count - 1)
        {
            LeftArmNum++;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmLeft, SetupInstance.SetArmLeft.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachLeft.transform.localPosition, SetUpCharacterBehaviour.RobotParts.LEFTARM);
        }

        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;
    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmLeft, SetupInstance.SetArmLeft.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachLeft.transform.localPosition, SetUpCharacterBehaviour.RobotParts.LEFTARM);
        }

        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;
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
    }

    public void NextRightArm()
    {
        if (RightArmNum < UnlockedRightArms.Count - 1)
        {
            RightArmNum++;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmRight, SetupInstance.SetArmRight.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachRight.transform.localPosition, SetUpCharacterBehaviour.RobotParts.RIGHTARM);
        }

        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;
    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;
            SetParts();
            SetupInstance.GetPart(SetupInstance.SetArmRight, SetupInstance.SetArmRight.prefab, Vector3.one, Vector3.zero,
                SetupInstance.ArmAttachRight.transform.localPosition, SetUpCharacterBehaviour.RobotParts.RIGHTARM);
        }

        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;
    }

    // Current Issue: Needs to set up a new scene once the button is clicked    ***
    // For bringing the character given to the "target range" area
    public void BringToTargetRange()
    {
        SaveParts(SetupInstance.RobotPartList); // Calls function to save parts for scene transition
        SceneManager.LoadScene("1.TargetRange");    // Switches to named scene
        //  NOTE: Anything called after will be applied to this scene and not the new scene.
        SceneManager.UnloadSceneAsync("257.CharacterSelectTest");   //  Unloads (resets) named scene
    }
    #endregion
}
