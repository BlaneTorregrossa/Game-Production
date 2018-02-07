using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public SetUpArm setupInstance;
    public GameObject currentProjectileObject;
    public int Health;

    void Start()
    {
        setupInstance.currentCharacter.Heath = 100;
    }

    void Update()
    {
        Health = setupInstance.currentCharacter.Heath;
    }

    public void ShootBasicProjectile()
    {
        
    }

    public void BasicMelee()
    {

    }

    public void TakeDamage()
    {
        setupInstance.currentCharacter.Heath -= 10;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Debug.Log("A projectile hit!");
            TakeDamage();
        }
    }
}
