using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    public Character character;
    public float characterHealth;
    public float leftDamage;
    public float rightDamage;
    IPartsProperties Parts;
    public Transform leftSpawn;
    public Transform rightSpawn;

    [HideInInspector]
    public GameObject firedProjectile;

    public IFireable leftArm { get { return character.Left as Arm; } }
    public IFireable rightArm { get { return character.Right as Arm; } }
     

    void Start()
    {         
        characterHealth = 100;
        character.Health = characterHealth;
        character.isDead = (character.Health <= 0);
        character.Damage = 5;
    }

    void Update()
    {
        if (Input.GetButton("LeftArm"))
        {
            leftArm.Fire(transform);

        }
        if (Input.GetButton("RightArm"))
        {
            rightArm.Fire(transform);
        }


        character.isDead = (character.Health <= 0);
        gameObject.SetActive(!character.isDead);
    }

}
