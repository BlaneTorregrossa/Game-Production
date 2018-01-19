using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  Very Messy
//  Needs More Work
public class FightCameraBehavior : MonoBehaviour
{
    public Camera ArenaCam;
    public GameObject CharacterA, CharacterB;
    public Vector3 newCamPos;
    public Vector3 characterPosDelta, altCharacterPosDelta;
    public float camScale;

    void Start()
    {
        newCamPos = new Vector3(0, 0, 0);
        camScale = 0;
        ArenaCam.transform.position = new Vector3(0, 20, 0);
    }

    void Update()
    {
        AdjustForPlayer();
    }

    public void AdjustForPlayer()
    {
        characterPosDelta = CharacterA.transform.position - CharacterB.transform.position;
        altCharacterPosDelta = CharacterB.transform.position - CharacterA.transform.position;
        camScale = characterPosDelta.x + characterPosDelta.z;

        if (characterPosDelta.x > altCharacterPosDelta.x || characterPosDelta.z > altCharacterPosDelta.z)
        {
            ArenaCam.transform.position = new Vector3(characterPosDelta.x, camScale, characterPosDelta.z);
            if (ArenaCam.transform.position.y <= 20)
            {
                ArenaCam.transform.position = new Vector3(characterPosDelta.x, 20, characterPosDelta.z);
            }
        }

        else if (characterPosDelta.x < altCharacterPosDelta.x || characterPosDelta.z < altCharacterPosDelta.z)
        {
            ArenaCam.transform.position = new Vector3(altCharacterPosDelta.x, camScale, altCharacterPosDelta.z);
            if (ArenaCam.transform.position.y <= 20)
            {
                ArenaCam.transform.position = new Vector3(altCharacterPosDelta.x, 20, altCharacterPosDelta.z);
            }
        }

    }
}
