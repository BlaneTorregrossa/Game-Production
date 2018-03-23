using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderBehaviour : MonoBehaviour {

    public Character characterConfig;   //  Instance of the character
    public GameObject playerController; //  Controller used for character
    
    void Start()
    {
        foreach(Part p in characterConfig.parts)
        {
            var part = Instantiate(p.prefab, playerController.transform) as GameObject; // instantiate parts and set parent for the part
            part.transform.localPosition = p.partPos;   //  Set offset

        }
            
    }
}
