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
    public List<Material> ArmTextureList;
    public List<Material> HeadTextureList;
    public List<Material> LegsTextureList; 

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

        PartDescriptionText.text = "";
        LeftArmNum = 0;
        RightArmNum = 0;
        LegsNum = 0;
        HeadNum = 0;
        SetParts();
    }

    void Update()
    {
        DontDestroyOnLoad(CharacterA);
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

        if (setupInstance.characterArmList.Count <= 0)
        {
            setupInstance.characterArmList.Add(setupInstance.setArm1);
            setupInstance.characterArmList.Add(setupInstance.setArm2);
        }

        CurrentLeftArmText.text = UnlockedLeftArms[LeftArmNum].partName;
        CurrentRightArmText.text = UnlockedRightArms[RightArmNum].partName;
        CurrentHeadText.text = UnlockedHeads[HeadNum].partName;
        CurrentLegsText.text = UnlockedLegs[LegsNum].partName;

    }

    #region Buttons
    public void NextLeftArm()
    {
        if (LeftArmNum <= UnlockedLeftArms.Count)
        {
            LeftArmNum++;
        }
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
        {
            LeftArmNum--;
        }
        PartDescriptionText.text = UnlockedLeftArms[LeftArmNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void NextRightArm()
    {
        if (RightArmNum <= UnlockedRightArms.Count)
        {
            RightArmNum++;
        }
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
        {
            RightArmNum--;
        }
        PartDescriptionText.text = UnlockedRightArms[RightArmNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void NextLegs()
    {
        if (LegsNum <= UnlockedLegs.Count)
        {
            LegsNum++;
        }
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void PrevLegs()
    {
        if (LegsNum > 0)
        {
            LegsNum--;
        }
        PartDescriptionText.text = UnlockedLegs[LegsNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void NextHead()
    {
        if (HeadNum <= UnlockedHeads.Count)
        {
            HeadNum++;
        }
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }

    public void PrevHead()
    {
        if (HeadNum > 0)
        {
            HeadNum--;
        }
        PartDescriptionText.text = UnlockedHeads[HeadNum].description;
        setupInstance.DestroyParts();
        SetParts();
        setupInstance.PositionCharacterParts();
    }
    #endregion
}
