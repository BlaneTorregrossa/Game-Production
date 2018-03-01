using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Class may need to be redone a bit
public class SetUpCharacter : MonoBehaviour
{

    #region Arms
    public Arm setArm1;
    public Arm setArm2;
    public List<Arm> characterArmList = new List<Arm>();
    public Arm currentArm;

    public GameObject ArmAttachLeft;
    public GameObject ArmAttachRight;
    public GameObject ArmObject;
    #endregion

    #region Legs
    public Legs setLegs;
    public Legs currentLegs;

    public GameObject LegsAttach;
    public GameObject LegsObject;
    #endregion

    #region Head
    public Head setHead;
    public Head currentHead;

    public GameObject HeadAttach;
    public GameObject HeadObject;
    #endregion


    public static GetSpawn SpawnInstance;

    public Character currentCharacter;
    public Character savedCharacter = null;
    public List<GameObject> bodyPartList = new List<GameObject>();
    public List<GameObject> savedCharacterParts = null;
    public GameObject CurrentCharacterBody;
    public GameObject SavedCharacterBody = null;


    private Quaternion currentRotationSet = new Quaternion(0, 0, 0, 0);
    private GameObject blank;

    void Start()
    {
        CurrentCharacterBody = new GameObject();
        SpawnInstance = GetComponent<GetSpawn>();

        #region Bad
        for (int b = 0; b < 4; b++)
            bodyPartList.Add(blank);


        for (int t = 0; t < 4; t++)
            Destroy(bodyPartList[t]);
        #endregion

        if (savedCharacter != null && savedCharacterParts != null)
        {
            SpawnInstance.MoveSpawnToArena();
            SpawnInstance.moveToSpawn();
            currentCharacter = savedCharacter;
            bodyPartList = savedCharacterParts;
            currentCharacter.name = "Character A";
        }

        else
        {
            SpawnInstance.MoveSpawnToCustomization();
            SpawnInstance.moveToSpawn();
            tag = "Character";
            currentRotationSet.eulerAngles = new Vector3(0, 0, 0);

            setArm1 = currentCharacter.Left;
            setArm2 = currentCharacter.Right;
            setLegs = currentCharacter.LegSet;
            setHead = currentCharacter.HeadPiece;

            setUpTempAttachPoints();
            PositionCharacterParts();

            if (currentCharacter.Display != true)
                transform.position = new Vector3(0, 5, transform.position.z);
        }

    }

    void Update()
    {
        CurrentCharacterBody = gameObject;
    }

    // Attach points (center) for customizable parts
    public void setUpTempAttachPoints()
    {
        ArmAttachLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ArmAttachLeft.transform.localScale = new Vector3(.25f, .25f, .25f);
        ArmAttachLeft.transform.SetParent(transform);
        ArmAttachLeft.transform.localPosition = new Vector3(-1, 0, 0);
        Destroy(ArmAttachLeft.GetComponent<BoxCollider>());

        ArmAttachRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ArmAttachRight.transform.localScale = new Vector3(.25f, .25f, .25f);
        ArmAttachRight.transform.SetParent(transform);
        ArmAttachRight.transform.localPosition = new Vector3(1, 0, 0);
        Destroy(ArmAttachRight.GetComponent<BoxCollider>());

        LegsAttach = GameObject.CreatePrimitive(PrimitiveType.Cube);
        LegsAttach.transform.localScale = new Vector3(.25f, .25f, .25f);
        LegsAttach.transform.SetParent(transform);
        LegsAttach.transform.localPosition = new Vector3(0, -1, 0);
        Destroy(LegsAttach.GetComponent<BoxCollider>());

        HeadAttach = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HeadAttach.transform.localScale = new Vector3(.25f, .25f, .25f);
        HeadAttach.transform.SetParent(transform);
        HeadAttach.transform.localPosition = new Vector3(0, 1, 0);
        Destroy(HeadAttach.GetComponent<BoxCollider>());
    }

    // Issues with the functions called here
    public void PositionCharacterParts()
    {
        PositionArm();
        PositionLegs();
        PositionHead();
        KeepCharacterSetup();
    }


    // Position arms based on Arm objects given
    public void PositionArm()
    {
        for (int i = 0; i < 2; i++)
        {
            currentArm = characterArmList[i];

            if (currentArm.isLeft)
            {
                ArmObject = Instantiate(currentArm.prefab);
                ArmObject.transform.SetParent(transform);
                ArmObject.transform.localScale = new Vector3(.75f, .75f, .75f);
                ArmObject.GetComponent<CapsuleCollider>().height = 1;
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = ArmAttachLeft.transform.position;
                ArmObject.transform.rotation = currentRotationSet;
                currentArm.armPos = ArmObject.transform.position;
                ArmObject.tag = "Character Part";
                if (bodyPartList[0] != null)
                {
                    Destroy(bodyPartList[0]);
                    bodyPartList[0] = ArmObject;
                }
                else
                {
                    bodyPartList[0] = ArmObject;
                }
            }

            else if (currentArm.isRight)
            {
                ArmObject = Instantiate(currentArm.prefab);
                ArmObject.transform.SetParent(transform);
                ArmObject.transform.localScale = new Vector3(.75f, .75f, .75f);
                ArmObject.GetComponent<CapsuleCollider>().height = 1;
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = ArmAttachRight.transform.position;
                ArmObject.transform.rotation = currentRotationSet;
                currentArm.armPos = ArmObject.transform.position;
                ArmObject.tag = "Character Part";
                if (bodyPartList[1] != null)
                {
                    Destroy(bodyPartList[1]);
                    bodyPartList[1] = ArmObject;
                }
                else
                {
                    bodyPartList[1] = ArmObject;
                }
            }
        }
    }

    //  Position Legs based on given Legs object
    public void PositionLegs()
    {
        currentLegs = setLegs;

        LegsObject = Instantiate(currentLegs.prefab);
        LegsObject.transform.SetParent(transform);
        LegsObject.transform.localScale = new Vector3(.75f, .75f, .75f);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        LegsObject.transform.position = LegsAttach.transform.position;
        LegsObject.transform.rotation = currentRotationSet;
        LegsObject.tag = "Character Part";
        if (bodyPartList[2] != null)
        {
            Destroy(bodyPartList[2]);
            bodyPartList[2] = LegsObject;
        }
        else
        {
            bodyPartList[2] = LegsObject;
        }

    }

    //  Position head based on given Head object
    public void PositionHead()
    {
        currentHead = setHead;

        HeadObject = Instantiate(currentHead.prefab);
        HeadObject.transform.SetParent(transform);
        HeadObject.transform.localScale = new Vector3(.75f, .75f, .75f);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        HeadObject.transform.position = HeadAttach.transform.position;
        HeadObject.transform.rotation = currentRotationSet;
        HeadObject.tag = "Character Part";
        if (bodyPartList[3] != null)
        {
            Destroy(bodyPartList[3]);
            bodyPartList[3] = HeadObject;
        }
        else
        {
            bodyPartList[3] = HeadObject;
        }

    }

    // Keeping selected character for scene transition
    public void KeepCharacterSetup()
    {
        SavedCharacterBody = PrefabUtility.CreatePrefab(
            "Assets/Prefabs/SavedCharacters/CharacterA.prefab",
            CurrentCharacterBody);
        savedCharacter = currentCharacter;
        savedCharacterParts = bodyPartList;

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(savedCharacter);
        for (int i = 0; i < savedCharacterParts.Count; i++)
            DontDestroyOnLoad(savedCharacterParts[i]);


    }
}
