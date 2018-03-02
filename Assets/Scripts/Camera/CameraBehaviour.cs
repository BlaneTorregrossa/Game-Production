using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// =*=
// Whole class needs to be redone
public class CameraBehaviour : MonoBehaviour
{
    public float fovLock;   // To clock Field of view when needed
    public float zoom, verticalZoom, horizontalZoom;    // Help determine camera position
    public GameObject CharacterA, CharacterB, camCenter;    // Objects involved
    public float focusAdjustX, focusAdjustY, focusAdjustZ;  // variables for scaling zoom
    public Camera cam;  // to refer to the camera properties

    private Quaternion camRotation = new Quaternion();  // Rotation of camera

    void Start()
    {
        fovLock = 0;
    }

    void Update()
    {
        SetCameraView();
    }

    //  Moves and updates the camera position based on the center of two given objects. Field of view eventually changes the further the distance between objects.
    public void SetCameraView()
    {
        camRotation.eulerAngles = new Vector3(60, 0, 0);    // starting rotation
        transform.rotation = camRotation;   // set the rotation
        zoom = Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position);  // To get the distacne of two main objects to help determine scaling for the camera
        horizontalZoom = CharacterA.transform.position.x - CharacterB.transform.position.x; // X axis/Horizontal
        verticalZoom = CharacterA.transform.position.z - CharacterB.transform.position.z;   // Z axis/Vertical

        //  Cam position based on x position
        if (horizontalZoom > 0)
        {
            focusAdjustY = 30;
        }
        else
        {
            focusAdjustX = 0;
            focusAdjustY = 30;
        }

        //  Cam Position based on z position
        if (verticalZoom != 0)
        {
            focusAdjustZ = camCenter.transform.position.z - 75;
            focusAdjustY = camCenter.transform.position.y + 70;
        }
        else
        {
            focusAdjustZ = 0;
            focusAdjustY = 30;
        }

        // Small zoom out for when players get further
        if (zoom > 60 && zoom < 100)
            cam.fieldOfView = zoom / 2;

        fovLock = cam.fieldOfView;  // Set lock for FOV

        // Prevent fov from getting any bigger
        if (zoom >= 100)
            cam.fieldOfView = fovLock;

        transform.position = new Vector3(focusAdjustX, zoom + focusAdjustY, focusAdjustZ) + PosLineUp(CharacterA, CharacterB, camCenter);
        //transform.rotation = RotationLineUp(CharacterA, CharacterB, camCenter);
    }

    public Vector3 PosLineUp(GameObject subTargetA, GameObject subTargetB, GameObject centerTarget)
    {
        float newX = 0, newY = 0, newZ = 0;

        #region Set X
        // A has greater x value
        if (subTargetA.transform.position.x > centerTarget.transform.position.x
            && subTargetB.transform.position.x < centerTarget.transform.position.x)
        {
            newX = (subTargetA.transform.position.x - centerTarget.transform.position.x) - subTargetA.transform.position.x;
        }
        // B has a greater x value
        if (subTargetB.transform.position.x > centerTarget.transform.position.x
            && subTargetA.transform.position.x < centerTarget.transform.position.x)
        {
            newX = (subTargetB.transform.position.x - centerTarget.transform.position.x) - subTargetB.transform.position.x;
        }
        #endregion

        #region Set Z
        // A has a greater z value
        if (subTargetA.transform.position.z > centerTarget.transform.position.z
            && subTargetB.transform.position.z < centerTarget.transform.position.z)
        {
            newZ = (subTargetA.transform.position.z - centerTarget.transform.position.z) - subTargetA.transform.position.z;
        }

        // B has a greater z value
        if (subTargetB.transform.position.z > centerTarget.transform.position.z
            && subTargetA.transform.position.z < centerTarget.transform.position.z)
        {
            newZ = (subTargetB.transform.position.z - centerTarget.transform.position.z) - subTargetB.transform.position.z;
        }
        #endregion

        return new Vector3(newX, newY, newZ);
    }

    //public Quaternion RotationLineUp(GameObject subTargetA, GameObject subTargetB, GameObject centerTarget)
    //{
    //    Quaternion newRotation = new Quaternion();
    //    float rotX = 0, rotY = 0, rotZ = 0;

    //    // For camera to be behind Target B
    //    if (subTargetA.transform.position.z > subTargetB.transform.position.z)
    //    {
    //        rotY = subTargetA.transform.position.x - centerTarget.transform.position.x;
    //    }

    //    // For camera to be behind Target A
    //    if (subTargetB.transform.position.z > subTargetA.transform.position.z)
    //    {
    //        rotY = subTargetB.transform.position.x - centerTarget.transform.position.x;
    //    }

    //    newRotation.eulerAngles = new Vector3(60, rotY, rotZ); // What's returned
    //    return newRotation;
    //}

}
