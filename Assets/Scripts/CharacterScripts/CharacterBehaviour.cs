using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    public Character character;
    public float Health;
   
    void Start()
    {
        Health = character.Health;
    }

    public void TakeDamage(float moddifier)
    {
        Health -= 1.5f * moddifier;
    }

}
