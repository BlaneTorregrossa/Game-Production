using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public float zoom;

    public GameObject CharacterA;
    public GameObject CharacterB;

    public GameObject camCenter;


    private Quaternion camRotation = new Quaternion();
    private float zoomlock;

    void Start()
    {
        transform.rotation = new Quaternion();
    }

    void Update()
    {
        CamZoom();
    }

    public void CamZoom()
    {
        #region W/O CineMachine
        //if (camCenter.transform.position.x >= 0)
        //{
        //    Quaternion camRotation = new Quaternion();
        //    camRotation.eulerAngles = new Vector3(45, 0, 0);

        //    transform.rotation = camRotation;
        //}

        //if (camCenter.transform.position.x <= 0)
        //{
        //    Quaternion camRotation = new Quaternion();
        //    camRotation.eulerAngles = new Vector3(45, 180, 0);

        //    transform.rotation = camRotation;
        //}

        #endregion

        // Need this in to work with cineMachine
        zoom = Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position);

        camRotation.eulerAngles = new Vector3(35, 0, 0);
        transform.rotation = camRotation;
        transform.position = new Vector3(camCenter.transform.position.x, transform.position.y + zoom, camCenter.transform.position.z);

    }

}
