using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  Will need modifications to adjust camera look.
public class PlayerCenterBehaviour : MonoBehaviour
{
    public Transform TargetA;  //  Object A
    public Transform TargetB;  //  Object B
    public Transform Camera; //  Camera transform

    public float CharacterToCharacterDistance;      //  Distance of Both Objects from each other
    public float CharacterAToCameraDistance;    //  Distance from a character to a camera
    public float CharacterBToCameraDistacne;    //  Distance from a character to a camera

    private Vector3 objectPosDelta; //  Position of center object in the world

    void Update()
    {
        SetCenter();    //  Calling funbction that sets this objects's position
        CharacterToCharacterDistance = Vector3.Distance(TargetA.transform.position, TargetB.transform.position);    //  Give distance between the targets
        CharacterAToCameraDistance = Vector3.Distance(TargetA.transform.position, Camera.transform.position);   //  Give distance between TargetA and the camera
        CharacterBToCameraDistacne = Vector3.Distance(TargetB.transform.position, Camera.transform.position);   //  Give distance between TargetB and the camera
    }

    //  To set the position in the world of this gameobject between two other given objects
    public void SetCenter()
    {
        // To get the center of the two objects
        if (Vector3.Distance(TargetA.transform.position, TargetB.transform.position) > 0.5f)
        {
            objectPosDelta = TargetB.transform.position + (TargetA.transform.position - TargetB.transform.position) / 2;   // Defining center area
            transform.position = objectPosDelta;    //  Set this objects position to the difference between the two objects
        }
        else
            return;
    }

}
