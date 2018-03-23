
using UnityEngine;

public class CharacterHandoffBehaviour : MonoBehaviour {
    public Character characterConfig;   //  Character instance for setting character parts 
    public CharacterCustomizationBehaviour ccb; //  Instance of CharacterCustomizationBehaviour 
	
    //  Handoff Character Information
    public void Handoff()
    {
        characterConfig.parts = ccb.CustomizedCharacter.parts;  //  Sets given Character instance parts to be that are set on the CharacterCustomizationBehaviour
    }
}
