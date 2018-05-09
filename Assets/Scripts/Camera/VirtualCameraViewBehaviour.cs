using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Will be cleaned up and redone once desired areas for the camera movement is found
public class VirtualCameraViewBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform CameraPos;    //  Camera Transform
    [SerializeField]
    private GameObject CenterObject;    //  Used for getting the PlayerCenterBehaviourComponent information
    private PlayerCenterBehaviour Center;   //  Used for getting Center information
    [SerializeField]
    private Vector3 CamBoundries;   //  Boundries for the Camera Movement
    [SerializeField]
    private float CamYModifier, CamZModifier;   //  Moddifiers for the how the camera moves position on the Y or Z axis
    [SerializeField]
    private float CloseViewY, CloseViewZ;   //  Transform values for the camera when set in static position for x and y axis
    [SerializeField]
    private float CameraMovementUp; //  Modifier for how camera moves "upwards" in the world
    [SerializeField]
    private float CharacterDistanceThreshold;   //  Threshold for how close the characters can be
    private float YMovement, ZMovement; //  Axis movement for the camera's position

    void Start()
    {
        Center = CenterObject.GetComponent<PlayerCenterBehaviour>();    //  Assigning PlayerCenterComponent object
    }

    //  For updating Camrea Position Object
    void Update()
    {
        transform.position = CameraPositioning();   //  Setting camera's Current Position in the world
        transform.position = BoundryCheck();   //  Function to control if camera is in it's current set bounds
    }

    //  Set movement boundry for camera follow object on x y and z axis
    public Vector3 BoundryCheck()
    {
        Vector3 ReturnVector;
        float NewPosX = transform.position.x;
        float NewPosY = transform.position.y;
        float NewPosZ = transform.position.z;

        //  X axis boundry check
        if (transform.position.x > CamBoundries.x)
            NewPosX = CamBoundries.x;
        else if (transform.position.x < -CamBoundries.x)
            NewPosX = -CamBoundries.x;

        //  y axis boundry check
        if (transform.position.y > CamBoundries.y)
            NewPosY = CamBoundries.y;
        else if (transform.position.y < -CamBoundries.y)
            NewPosY = -CamBoundries.y;

        //  z axis boundry check
        if (transform.position.z > CamBoundries.z)
            NewPosZ = CamBoundries.z;
        else if (transform.position.z < -CamBoundries.z)
            NewPosZ = -CamBoundries.z;

        return ReturnVector = new Vector3(NewPosX, NewPosY, NewPosZ);   //  position returned to camera transform object
    }

    //  Returns specific position for the camera to move to
    public Vector3 CameraPositioning()
    {
        Vector3 ReturnVector = transform.position;  //  What will be returned

        YMovement = Center.CharacterToCharacterDistance / CamYModifier; //  position based on distanceand modifier for the y axis for the camera
        ZMovement = -Center.CharacterToCharacterDistance / CamZModifier;    //  position based on distanceand modifier for the z axis for the camera

        //  If the distance of both targets exceeeds the given value then the camera adjusts to keep both characters in view
        if (Center.CharacterToCharacterDistance > CharacterDistanceThreshold)
            ReturnVector = new Vector3(Center.transform.position.x,
                Center.CharacterToCharacterDistance * (YMovement / CameraMovementUp),
                Center.CharacterToCharacterDistance * (ZMovement));
        //  else the camera is in a semi-lcoked position that can see both targets
        else
            ReturnVector = new Vector3(CenterObject.transform.position.x, CloseViewY, CloseViewZ);

        return ReturnVector;    //  Return camera camera position
    }

}
