using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    public Character character;
    public float characterHealth;
    public float leftDamage;
    public float rightDamage;
    public GameObject projectile;

    [HideInInspector]
    public GameObject firedProjectile;

    void Start()
    {
        if (characterHealth <= 0)
        {
            characterHealth = 100;
        }
        character.Health = characterHealth;
        character.isDead = false;
        character.Damage = 5;
        SetBehaviour();
    }

    void Update()
    {
        if (character.Health <= 0)
            character.isDead = true;
        else if (character.Health > 0)
            character.isDead = false;

        if (character.isDead == true)
            gameObject.SetActive(false);
        else if (character.isDead == false)
            gameObject.SetActive(true);
    }

    public void SetBehaviour()
    {
        character.LeftArmBehaviour = gameObject.AddComponent<ArmBehaviour>();
        character.RightArmBehaviour = gameObject.AddComponent<ArmBehaviour>();
        character.HeadBehaviour = gameObject.AddComponent<HeadBehaviour>();
        character.LeftArmBehaviour.ArmConfig = character.Left as Arm;
        character.RightArmBehaviour.ArmConfig = character.Right as Arm;
        character.HeadBehaviour.HeadConfig = character.HeadPiece as Head;
        leftDamage = character.LeftArmBehaviour.ArmConfig.damageNum;
        rightDamage = character.RightArmBehaviour.ArmConfig.damageNum;
    }
    
    public void SetcurrentDamage(bool isright)
    {
        if(isright)
        {
            character.Damage = rightDamage;
        }
        else
        {
            character.Damage = leftDamage;
        }
    }

    public void ShootProjectile()
    {
        firedProjectile = Instantiate(projectile, character.projectileSpawn.position, character.projectileSpawn.rotation);
        firedProjectile.transform.forward = character.projectileSpawn.forward;
        firedProjectile.AddComponent<ProjectileBehavior>();
        firedProjectile.GetComponent<ProjectileBehavior>().SetOwner(character);
        Destroy(firedProjectile, 2f);
    }
}
