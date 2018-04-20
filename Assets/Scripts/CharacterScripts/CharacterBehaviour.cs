using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    public Character character;
    public float characterHealth;
    public float leftDamage;
    public float rightDamage;

    public ArmBehaviour LeftArmBehaviour;
    public ArmBehaviour RightArmBehaviour;
    public HeadBehaviour HeadBehaviour;

    [HideInInspector]
    public GameObject firedProjectile;

    void Start()
    {

        SetBehaviour();
        if (characterHealth <= 0)
        {
            characterHealth = 100;
        }
        character.Health = characterHealth;
        character.isDead = false;
        character.Damage = 5;
    }

    void Update()
    {
        if(Input.GetButton("LeftArm"))
        {
            ShootProjectile(LeftArmBehaviour.ArmConfig.Projectile);
        }

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
        var la = gameObject.AddComponent<ArmBehaviour>();
        var ra = gameObject.AddComponent<ArmBehaviour>();
        var h = gameObject.AddComponent<HeadBehaviour>();
        la.ArmConfig = character.Left as Arm;
        ra.ArmConfig = character.Right as Arm;
        h.HeadConfig = character.HeadPiece as Head;
        LeftArmBehaviour = la;
        RightArmBehaviour = ra;
        HeadBehaviour = h;
        leftDamage = LeftArmBehaviour.ArmConfig.damageNum;
        rightDamage = RightArmBehaviour.ArmConfig.damageNum;
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

    public void ShootProjectile(IShootable shootable)
    {
        firedProjectile = Instantiate(shootable.projectile, character.projectileSpawn.position, character.projectileSpawn.rotation);
        firedProjectile.transform.forward = character.projectileSpawn.forward;
        firedProjectile.AddComponent<ProjectileBehavior>();
        firedProjectile.GetComponent<ProjectileBehavior>().SetOwner(character);
        firedProjectile.AddComponent<Rigidbody>().velocity += gameObject.transform.forward * character.projectileSpeed;
        Destroy(firedProjectile, 2f);
    }
}
