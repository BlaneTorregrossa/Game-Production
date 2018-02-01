using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public SetUpArm setupInstance;

	void Start ()
    {
        setupInstance.currentCharacter.Heath = 100;
	}
	
	void Update ()
    {
		
	}

    void TakeDamage()
    {

    }
}
