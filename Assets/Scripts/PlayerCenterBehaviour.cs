using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenterBehaviour : MonoBehaviour
{

    public GameObject CharacterA;
    public GameObject CharacterB;

    public float zoomScale;

    private Vector3 objectPosDelta;

    void Update()
    {
        SetCenter();
    }

    public Vector3 SetCenter()
    {

        // To get the center of the two players
        if (Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position) > 1)
        {
            objectPosDelta = CharacterB.transform.position + (CharacterA.transform.position - CharacterB.transform.position) / 2;   // Center area
        }

        zoomScale = Vector3.Distance(CharacterA.transform.position, CharacterB.transform.position);
        transform.position = objectPosDelta + new Vector3(0 , zoomScale / 2, 0);
        return objectPosDelta;
    }
}
