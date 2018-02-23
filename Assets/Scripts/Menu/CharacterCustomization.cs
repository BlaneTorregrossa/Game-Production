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
    public Character customizedCharacter = new Character();

    public List<Arm> UnlockedLeftArms = new List<Arm>();
    public List<Arm> UnlockedRightArms = new List<Arm>();
    public List<Legs> UnlockedLegs = new List<Legs>();
    public List<Head> UnlockedHeads = new List<Head>();


    private int LeftArmNum;
    private int RightArmNum;
    private int LegsNum;
    private int HeadNum;

    void Start()
    {
        LeftArmNum = 0;
        RightArmNum = 0;
        LegsNum = 0;
        HeadNum = 0;
        customizedCharacter.Display = true;
        setupInstance = CharacterA.AddComponent<SetUpCharacter>();
    }

    void Update()
    {
        UpdateCharacter();
    }

    public void SetParts()
    {
        customizedCharacter.Left = UnlockedLeftArms[LeftArmNum];
        customizedCharacter.Right = UnlockedRightArms[RightArmNum];
        customizedCharacter.LegSet = UnlockedLegs[LegsNum];
        customizedCharacter.HeadPiece = UnlockedHeads[HeadNum];
        setupInstance.currentCharacter = customizedCharacter;
    }

    public void UpdateCharacter()
    {
        SetParts();
        setupInstance.PositionCharacterParts();

    }


    #region Buttons
    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedLeftArms.Count)
        {
            LeftArmNum++;
        }
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;
        }
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
    }

    public void NextRightArm()
    {
        if (RightArmNum < UnlockedRightArms.Count)
        {
            RightArmNum++;
        }
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;
        }
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
    }

    public void NextLegs()
    {
        if (LegsNum < UnlockedLegs.Count)
        {
            LegsNum++;
        }
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
    }

    public void PrevLegs()
    {
        if (LegsNum > 0)
        {
            LegsNum--;
        }
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
    }

    public void NextHead()
    {
        if (HeadNum < UnlockedHeads.Count)
        {
            HeadNum++;
        }
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
    }

    public void PrevHead()
    {
        if (HeadNum > 0)
        {
            HeadNum--;
        }
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
    }

    #endregion
}
