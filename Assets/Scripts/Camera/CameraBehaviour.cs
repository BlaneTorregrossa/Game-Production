using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviour : MonoBehaviour
{

    public float zoom, verticalZoom, horizontalZoom;
    public GameObject CharacterA, CharacterB, camCenter;
    public float focusAdjustX, focusAdjustY, focusAdjustZ;

    private Quaternion camRotation = new Quaternion();
    private float zoomlock;

    void Start()
    {
    }

    void Update()
    {
        CamZoom();
    }

    public void CamZoom()
    {
        camRotation.eulerAngles = new Vector3(60, 0, 0);
        transform.rotation = camRotation;
        zoom = Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position);
        horizontalZoom = CharacterA.transform.position.x - CharacterB.transform.position.x;
        verticalZoom = CharacterA.transform.position.z - CharacterB.transform.position.z;
        transform.rotation = camRotation;


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

        transform.position = new Vector3(focusAdjustX, zoom + focusAdjustY, focusAdjustZ);

    }

}
