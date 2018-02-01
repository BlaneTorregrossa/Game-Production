using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//  Good For now might need adjustments given what arena the characters are to be placed in
public class CameraBehaviour : MonoBehaviour
{

    public float zoom, verticalZoom, horizontalZoom;
    public GameObject CharacterA, CharacterB, camCenter;
    public float focusAdjustX, focusAdjustY, focusAdjustZ;
    public Camera cam;

    private Quaternion camRotation = new Quaternion();
    private float zoomlock;

    void Start()
    {
    }

    void Update()
    {
        CamZoom();
    }

    //  Moves and updates the camera position based on the center of two given objects. Field of view eventually changes the further the distance between objects.
    public void CamZoom()
    {
        camRotation.eulerAngles = new Vector3(60, 0, 0);
        transform.rotation = camRotation;
        zoom = Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position);
        horizontalZoom = CharacterA.transform.position.x - CharacterB.transform.position.x;
        verticalZoom = CharacterA.transform.position.z - CharacterB.transform.position.z;
        transform.rotation = camRotation;

        //  Zoom based on x position
        if (horizontalZoom > 0)
        {
            focusAdjustX = camCenter.transform.position.x;
            focusAdjustY = 30;
        }
        else
        {
            focusAdjustX = 0;
            focusAdjustY = 30;
        }

        //  Zoom based on z position
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

        if (zoom > 75)
            cam.fieldOfView = zoom / 2;

        transform.position = new Vector3(focusAdjustX, zoom + focusAdjustY, focusAdjustZ);

    }

}
