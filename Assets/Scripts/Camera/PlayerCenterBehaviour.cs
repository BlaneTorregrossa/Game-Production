using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


//  Will need modifications to adjust camera look.
public class PlayerCenterBehaviour : MonoBehaviour
{
    public GameObject TargetA;  //  Object A
    public GameObject TargetB;  //  Object B

    public float Distance;      //  Distance of Both Objects from each other

    private Vector3 objectPosDelta; //  Position of center object in the world

    void Update()
    {
        SetCenter();
        Distance = Vector3.Distance(TargetA.transform.position, TargetB.transform.position);
    }

    //  To set the position in the wrold of this gameobject between two other given objects
    public void SetCenter()
    {
        // To get the center of the two objects
        if (Vector3.Distance(TargetA.transform.position, TargetB.transform.position) > 0.5f)
        {
            objectPosDelta = TargetB.transform.position + (TargetA.transform.position - TargetB.transform.position) / 2;   // Center area
        }
        transform.position = objectPosDelta;
    }

}
