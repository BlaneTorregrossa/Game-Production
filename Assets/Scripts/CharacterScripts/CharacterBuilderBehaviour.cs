using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderBehaviour : MonoBehaviour, IPartsProperties
{

    public Character characterConfig;   //  Instance of the character
    public GameObject playerController; //  Controller used for character
    private List<GameObject> partsList;
    public GameObject LeftArm { get { return partsList[0]; } }
    public GameObject RightArm { get { return partsList[1]; } }

    public GameObject Legs { get { return partsList[2]; } }

    public GameObject Head { get { return partsList[3]; } }

    void Start()
    {
        partsList = new List<GameObject>();
        foreach (var p in characterConfig.parts)
        {
            var part = Instantiate(p.prefab, playerController.transform) as GameObject; // instantiate parts and set parent for the part
            part.transform.localPosition = p.partPos;   //  Set offset 
            partsList.Add(part);
        }

    }
}
