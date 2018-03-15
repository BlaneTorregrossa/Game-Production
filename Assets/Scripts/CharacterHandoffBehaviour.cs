
using UnityEngine;

public class CharacterHandoffBehaviour : MonoBehaviour {
    public Character characterConfig;
    public CharacterCustomizationBehaviour ccb;
	
    public void Handoff()
    {
        characterConfig.parts = ccb.CustomizedCharacter.parts;
    }
}
