using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraFollowBehaviour : MonoBehaviour
{

    
    [SerializeField]
    private GameObject CenterObject;
    private PlayerCenterBehaviour Center;
    [SerializeField]
    private Transform CameraPos;
    private float TargetsDistance;
    [SerializeField]
    private float YModifier, ZModifier;
    private float CameraStartX, CameraStartY, CameraStartZ;

    void Start()
    {
        Center = CenterObject.GetComponent<PlayerCenterBehaviour>();
        CameraStartX = CameraPos.transform.position.x;
        CameraStartY = CameraPos.transform.position.y;
        CameraStartZ = CameraPos.transform.position.z;
    }

    void Update()
    {
        TargetsDistance = Center.Distance;
        transform.position = new Vector3(CameraStartX, (TargetsDistance / YModifier) + CameraStartY, (TargetsDistance / ZModifier) + CameraStartZ);    //  
    }
}
