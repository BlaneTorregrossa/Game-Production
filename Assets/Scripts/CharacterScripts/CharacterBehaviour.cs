using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    public Character character;
    public float Health;
    public bool isDead;

    void Start()
    {
        Health = character.Health;
        isDead = false;
    }

    void Update()
    {
        if (Health <= 0)
            isDead = true;
        else if (Health > 0)
            isDead = false;

        if (isDead == true)
            gameObject.SetActive(false);
        else if (isDead == false)
            gameObject.SetActive(true);

        // Temporary Since no proper attacks are added
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float moddifier)
    {
        Health -= 5f * moddifier;
    }

}
