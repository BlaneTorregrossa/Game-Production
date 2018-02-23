using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =*=
// Trying changes for camera without messing up previous Cam setup
public class CombatCamBehaviour : MonoBehaviour
{

    public float fovLock, targetDistance, verticalZoom, horizontalZoom;
    public GameObject CharacterA, CharacterB, CamTarget;
    public float camPosX, camPosY, camPosZ;
    public Camera Cam;

    private Quaternion camRotation = new Quaternion();

    void Start()
    {
        camPosX = 0;
        camPosY = 0;
        camPosZ = 0;
    }

    void Update()
    {
        SetCamera();
    }

    public void SetCamera()
    {
        camRotation.eulerAngles = new Vector3(60, 0, 0);
        transform.rotation = camRotation;
        targetDistance = Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position);

        #region Horizontal Zoom

        if (CharacterA.transform.position.x > CharacterB.transform.position.x)
            horizontalZoom = -(CharacterA.transform.position.x + CharacterB.transform.position.x);

        else if (CharacterB.transform.position.x > CharacterA.transform.position.x)
            horizontalZoom = -(CharacterB.transform.position.x + CharacterA.transform.position.x);

        else
            horizontalZoom = 0;

        #endregion

        #region Vertical Zoom
        if (CharacterA.transform.position.z > CharacterB.transform.position.z)
            verticalZoom = CharacterA.transform.position.z - CharacterB.transform.position.z;

        if (CharacterB.transform.position.z > CharacterB.transform.position.z)
            verticalZoom = CharacterB.transform.position.z - CharacterA.transform.position.z;

        else
            verticalZoom = 0;
        #endregion

        if (horizontalZoom != 0)
        {
            camPosX = (CamTarget.transform.position.x - horizontalZoom) / 4;
        }

        if (verticalZoom != 0)
        {
            camPosZ = (CamTarget.transform.position.z - verticalZoom);
            camPosY = (CamTarget.transform.position.y + verticalZoom);
        }

        if (targetDistance > 60 && targetDistance < 120)
            Cam.fieldOfView = targetDistance / 2;

        fovLock = Cam.fieldOfView;

        if (targetDistance >= 120)
            Cam.fieldOfView = fovLock;

        transform.position = new Vector3(camPosX, (targetDistance + camPosY) + 30, camPosZ);
        //transform.rotation = SetCamRotation(CharacterA, CharacterB, CamTarget);
    }

    public Quaternion SetCamRotation(GameObject ObjectA, GameObject ObjectB, GameObject FocusTarget)
    {
        Quaternion newRotation = new Quaternion();

        return newRotation;
    }
}
