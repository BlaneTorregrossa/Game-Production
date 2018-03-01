using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{

    public static SetUpCharacter setupInstance;

    public GameObject CharacterA;
    public Text CurrentLeftArmText;
    public Text CurrentRightArmText;
    public Text CurrentLegsText;
    public Text CurrentHeadText;
    public Text PartDescriptionText;
    public Character customizedCharacter;

    public List<Arm> UnlockedLeftArms;
    public List<Arm> UnlockedRightArms;
    public List<Legs> UnlockedLegs;
    public List<Head> UnlockedHeads;

    private int LeftArmNum;
    private int RightArmNum;
    private int LegsNum;
    private int HeadNum;

    void Start()
    {
        setupInstance = CharacterA.AddComponent<SetUpCharacter>();

        customizedCharacter = new Character
        {
            name = "Character A",
            Name = "Character A",
            Display = true
        };

        PartDescriptionText.text = "DESCRIPTION HERE";
        LeftArmNum = 0;
        RightArmNum = 0;
        LegsNum = 0;
        HeadNum = 0;
        SetParts();
    }

    void Update()
    {
    }

    public void SetParts()
    {
        customizedCharacter.Left = UnlockedLeftArms[LeftArmNum];
        customizedCharacter.Right = UnlockedRightArms[RightArmNum];
        customizedCharacter.LegSet = UnlockedLegs[LegsNum];
        customizedCharacter.HeadPiece = UnlockedHeads[HeadNum];
        setupInstance.currentCharacter = customizedCharacter;

        setupInstance.setArm1 = UnlockedLeftArms[LeftArmNum];
        setupInstance.setArm2 = UnlockedRightArms[RightArmNum];
        setupInstance.setLegs = UnlockedLegs[LegsNum];
        setupInstance.setHead = UnlockedHeads[HeadNum];

        if (setupInstance.characterArmList.Count == 0)
        {
            setupInstance.characterArmList.Add(setupInstance.setArm1);
            setupInstance.characterArmList.Add(setupInstance.setArm2);
        }

        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName;
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;

    }

    // Buttons for switching parts + changes description
    #region Buttons
    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedLeftArms.Count - 1)
        {
            LeftArmNum++;
            Debug.Log("LeftArmNum: " + LeftArmNum);
            setupInstance.characterArmList[0] = UnlockedLeftArms[LeftArmNum];
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;

    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;
            Debug.Log("LeftArmNum: " + LeftArmNum);
            setupInstance.characterArmList[0] = UnlockedLeftArms[LeftArmNum];
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;

    }

    public void NextRightArm()
    {
        if (RightArmNum < UnlockedRightArms.Count - 1)
        {
            RightArmNum++;
            Debug.Log("RightArmNum: " + RightArmNum);
            setupInstance.characterArmList[1] = UnlockedRightArms[RightArmNum];
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;

    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;
            Debug.Log("RightArmNum: " + RightArmNum);
            setupInstance.characterArmList[1] = UnlockedRightArms[RightArmNum];
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;

    }

    public void NextLegs()
    {
        if (LegsNum < UnlockedLegs.Count - 1)
        {
            LegsNum++;
            Debug.Log("LevsNum: " + LegsNum);
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedLegs[LegsNum].description;

    }

    public void PrevLegs()
    {
        if (LegsNum > 0)
        {
            LegsNum--;
            Debug.Log("LegsNum: " + LegsNum);
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedLegs[LegsNum].description;

    }

    public void NextHead()
    {
        if (HeadNum < UnlockedHeads.Count - 1)
        {
            HeadNum++;
            Debug.Log("HeadNum: " + HeadNum);
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
    }

    public void PrevHead()
    {
        if (HeadNum > 0)
        {
            HeadNum--;
            Debug.Log("HeadNum: " + HeadNum);
            SetParts();
            setupInstance.PositionCharacterParts();
        }

        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
    }
    #endregion

}
