using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{

    public static SetUpCharacter setupInstance;

    public Character customizedCharacter = setupInstance.currentCharacter;

    public List<Arm> UnlockedArms = new List<Arm>();
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
    }

    void Update()
    {

    }

    public void SetParts()
    {

    }

    public void UpdateCharacter()
    {

    }


    #region Buttons
    public void NextLeftArm()
    {
        if (LeftArmNum < UnlockedArms.Count)
            LeftArmNum++;
    }

    public void PrevLeftArm()
    {
        if (LeftArmNum > 0)
            LeftArmNum--;
    }

    public void NextRightArm()
    {
        if (RightArmNum < UnlockedArms.Count)
            RightArmNum++;
    }

    public void PrevRightArm()
    {
        if (RightArmNum > 0)
            RightArmNum--;
    }

    public void NextLegs()
    {
        if (LegsNum < UnlockedLegs.Count)
            LegsNum++;
    }

    public void PrevLegs()
    {
        if (LegsNum > 0)
            LegsNum--;
    }

    public void NextHead()
    {
        if (HeadNum < UnlockedHeads.Count)
            HeadNum++;
    }

    public void PrevHead()
    {
        if (HeadNum > 0)
            HeadNum--;
    }

    #endregion
}
