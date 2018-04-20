using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Will be cleaned up and redone once desired areas for the camera movement is found
public class VirtualCameraViewBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform CameraPos;
    [SerializeField]
    private GameObject CenterObject;
    private PlayerCenterBehaviour Center;
    [SerializeField]
    private Vector3 CamBoundries;
    [SerializeField]
    private float CamYModifier, CamZModifier;
    [SerializeField]
    private float CloseViewY, CloseViewZ;

    // To not be changed in inspector    ***
    [SerializeField]
    private float YMovement, ZMovement;

    private Vector3 CameraPosStart;

    void Start()
    {
        Center = CenterObject.GetComponent<PlayerCenterBehaviour>();
        CameraPosStart = CameraPos.transform.position;
    }

    //  For updating Camrea Position Object
    void Update()
    {
        transform.position = CameraPositioning();
        transform.position = BoundryCheck();   //  Function to control if camera is in it's current set bounds
    }

    //  Set Boundry for camera follow object on x y and z axis
    //  Can be simplified
    public Vector3 BoundryCheck()
    {
        Vector3 ReturnVector;
        float NewPosX = transform.position.x;
        float NewPosY = transform.position.y;
        float NewPosZ = transform.position.z;

        if (transform.position.x > CamBoundries.x)
            NewPosX = CamBoundries.x;
        else if (transform.position.x < -CamBoundries.x)
            NewPosX = -CamBoundries.x;

        if (transform.position.y > CamBoundries.y)
            NewPosY = CamBoundries.y;
        else if (transform.position.y < -CamBoundries.y)
            NewPosY = -CamBoundries.y;

        if (transform.position.z > CamBoundries.z)
            NewPosZ = CamBoundries.z;
        else if (transform.position.z < -CamBoundries.z)
            NewPosZ = -CamBoundries.z;

        return ReturnVector = new Vector3(NewPosX, NewPosY, NewPosZ);
    }

    public Vector3 CameraPositioning()
    {
        Vector3 ReturnVector = transform.position;

        YMovement = Center.CharacterToCharacterDistance / CamYModifier;

        ZMovement = -Center.CharacterToCharacterDistance / CamZModifier;

        if (Center.CharacterToCharacterDistance > 10)
            ReturnVector = new Vector3(Center.transform.position.x,
                Center.CharacterToCharacterDistance * (YMovement / 2),
                Center.CharacterToCharacterDistance * (ZMovement));
        else
            ReturnVector = new Vector3(CenterObject.transform.position.x, CloseViewY, CloseViewZ);

        return ReturnVector;
    }

}
