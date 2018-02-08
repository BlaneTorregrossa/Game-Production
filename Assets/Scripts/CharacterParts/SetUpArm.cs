using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Need a different class name
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

    // Not clear if we need this
    #region Head
    public Head setHead;
    public Head currentHead;

    public GameObject HeadObject;
    #endregion


    //Very Temporary 
    public GameObject currentProjectileObject;

    // Very Temporary
    public Character currentCharacter;

    public List<GameObject> bodyPartList = new List<GameObject>();
    private Quaternion currentRotationSet;

    void Start()
    {
        this.tag = "Character";
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);

        setArm1 = currentCharacter.Left;
        setArm2 = currentCharacter.Right;

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

            if (currentArm.isLeft)
            {
                ArmObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                ArmObject.transform.SetParent(transform);
                ArmObject.transform.localScale = new Vector3(.75f, .75f, .75f);
                ArmObject.GetComponent<CapsuleCollider>().height = 2.5f;
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = transform.position + new Vector3(-3, 0, 0);
                ArmObject.transform.rotation = currentRotationSet;
                currentArm.armPos = ArmObject.transform.position;
                ArmObject.tag = "Character";
                bodyPartList.Add(ArmObject);
            }

            else if (currentArm.isRight)
            {
                ArmObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                ArmObject.transform.SetParent(transform);
                ArmObject.transform.localScale = new Vector3(.75f, .75f, .75f);
                ArmObject.GetComponent<CapsuleCollider>().height = 2.5f;
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = transform.position + new Vector3(3, 0, 0);
                ArmObject.transform.rotation = currentRotationSet;
                currentArm.armPos = ArmObject.transform.position;
                ArmObject.tag = "Character";
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
        LegsObject.transform.position = transform.position + new Vector3(0, -3f, 0);
        LegsObject.transform.rotation = currentRotationSet;
        LegsObject.tag = "Character";
        bodyPartList.Add(LegsObject);
    }

    public void PositionHead()
    {
        currentHead = setHead;

        HeadObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        HeadObject.transform.SetParent(transform);
        HeadObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        HeadObject.transform.position = transform.position + new Vector3(0, 3f, 0);
        HeadObject.transform.rotation = currentRotationSet;
        LegsObject.tag = "Character";
        bodyPartList.Add(HeadObject);

    }

    // Very Temporary needs to be in player controller 
    // THIS SHOULD NOT BE HERE ON FINAL BUILD
    public void Attack(Arm leftArm, Arm rightArm)
    {
        if (Input.GetKeyDown(KeyCode.Q) && leftArm.isLeft == true)
        {
            if (leftArm.isMelee == true)
            {
                currentRotationSet.eulerAngles = new Vector3(90, 0, 0);
                bodyPartList[0].transform.rotation = currentRotationSet;
                bodyPartList[0].transform.position = transform.position + new Vector3(-3, 0, 2.5f);
                bodyPartList[0].tag = "MeleeArm";
            }

            if (leftArm.isRanged)
            {
                currentRotationSet.eulerAngles = new Vector3(90, 0, 0);
                bodyPartList[0].transform.rotation = currentRotationSet;
                bodyPartList[0].tag = "RangedArm";
                GameObject newProjectile = Instantiate(currentProjectileObject, leftArm.armPos + transform.forward, currentProjectileObject.transform.rotation);
                ProjectileBehavior pb = newProjectile.AddComponent<ProjectileBehavior>();
                pb.character = this;
                newProjectile.tag = "Bullet";
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q) && leftArm.isLeft == true)
        {
            bodyPartList[0].transform.position = transform.position + new Vector3(-3, 0, 0);
            currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
            bodyPartList[0].transform.rotation = currentRotationSet;
            bodyPartList[0].tag = "Character";
        }

        if (Input.GetKeyDown(KeyCode.E) && rightArm.isRight == true)
        {
            if (rightArm.isMelee == true)
            {
                currentRotationSet.eulerAngles = new Vector3(90, 0, 0);
                bodyPartList[1].transform.rotation = currentRotationSet;
                bodyPartList[1].transform.position = transform.position + new Vector3(3, 0, 2.5f);
                bodyPartList[1].tag = "MeleeArm";
            }

            if (rightArm.isRanged)
            {
                currentRotationSet.eulerAngles = new Vector3(90, 0, 0);
                bodyPartList[1].transform.rotation = currentRotationSet;
                bodyPartList[1].tag = "RangedArm";
                GameObject newProjectile = Instantiate(currentProjectileObject, rightArm.armPos + transform.forward, currentProjectileObject.transform.rotation);
                ProjectileBehavior pb = newProjectile.AddComponent<ProjectileBehavior>();
                pb.character = this;
                newProjectile.tag = "Bullet";
            }
        }
        else if (Input.GetKeyUp(KeyCode.E) && rightArm.isRight == true)
        {
            currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
            bodyPartList[1].transform.rotation = currentRotationSet;
            bodyPartList[1].transform.position = transform.position + new Vector3(3, 0, 0);
            bodyPartList[1].tag = "Character";
        }
    }


}
