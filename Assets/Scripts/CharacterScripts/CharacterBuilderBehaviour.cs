using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderBehaviour : MonoBehaviour {

    public Character characterConfig;
    public GameObject playerController;
    
    void Start()
    {
        foreach(Part p in characterConfig.parts)
        {
            var part = Instantiate(p.prefab, playerController.transform) as GameObject;
            part.transform.localPosition = p.partPos;

        }
            
    }
}
