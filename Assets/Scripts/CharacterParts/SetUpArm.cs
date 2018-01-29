using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpArm : MonoBehaviour
{

    #region Arms
    public Arm setArm1;
    public Arm setArm2;
    public List<Arm> characterArmList = new List<Arm>();
    public Arm currentArm;

    public GameObject ArmObject;
    #endregion

    #region Legs
    public Legs setLegs;
    public Legs currentLegs;

    public GameObject LegsObject;
    #endregion

    #region Head
    public Head setHead;
    public Head currentHead;

    public GameObject HeadObject;
    #endregion

    private List<GameObject> bodyPartList = new List<GameObject>();
    private Quaternion currentRotationSet;

    void Start()
    {
        characterArmList.Add(setArm1);
        characterArmList.Add(setArm2);
        PositionCharacterParts();
    }

    void Update()
    {
        Attack(characterArmList[0], characterArmList[1]);
    }

    public void PositionCharacterParts()
    {
        PositionArm();
        PositionLegs();
        PositionHead();
    }

    public void PositionArm()
    {
        for (int i = 0; i < 2; i++)
        {
            currentArm = characterArmList[i];

            ArmObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            ArmObject.transform.SetParent(transform);
            ArmObject.transform.localScale = new Vector3(.5f, .5f, .5f);


            if (currentArm.isLeft)
            {
                currentRotationSet.eulerAngles = new Vector3(90, 0, 0);
                ArmObject.transform.position = transform.position + new Vector3(-1, 0, 0);
                ArmObject.transform.rotation = currentRotationSet;
                bodyPartList.Add(ArmObject);
            }

            else if (currentArm.isRight)
            {
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = transform.position + new Vector3(1, 0, 0);
                ArmObject.transform.rotation = currentRotationSet;
                bodyPartList.Add(ArmObject);
            }
        }
    }

    public void PositionLegs()
    {
        currentLegs = setLegs;

        LegsObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        LegsObject.transform.SetParent(transform);
        LegsObject.transform.localScale = new Vector3(.75f, .75f, .75f);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        LegsObject.transform.position = transform.position + new Vector3(0, -1f, 0);
        LegsObject.transform.rotation = currentRotationSet;
        bodyPartList.Add(LegsObject);
    }

    public void PositionHead()
    {
        currentHead = setHead;

        HeadObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        HeadObject.transform.SetParent(transform);
        HeadObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        HeadObject.transform.position = transform.position + new Vector3(0, 1f, 0);
        HeadObject.transform.rotation = currentRotationSet;
        bodyPartList.Add(HeadObject);

    }

    // Very Temporary
    public void Attack(Arm leftArm, Arm rightArm)
    {
        if (Input.GetKeyDown(KeyCode.Q) && leftArm.isLeft == true)
        {
            if (leftArm.isMelee == true)
            {
                bodyPartList[0].transform.position = transform.position + new Vector3(-1, 0, 2.5f);
            }

            if (leftArm.isRanged)
            {

            }
        }
        else if (Input.GetKeyUp(KeyCode.Q) && leftArm.isLeft == true)
        {
            bodyPartList[0].transform.position = transform.position + new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.E) && rightArm.isRight == true)
        {
            if (rightArm.isMelee == true)
            {
                bodyPartList[1].transform.position = transform.position + new Vector3(1, 0, 2.5f);
            }

            if (rightArm.isRanged)
            {
                
            }
        }
    }
}
