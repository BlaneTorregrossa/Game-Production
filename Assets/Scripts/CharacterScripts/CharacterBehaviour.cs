using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    public Character character;
    public float characterHealth;
    public float leftDamage;
    public float rightDamage;

    public GameObject leftObject;
    public GameObject rightObject;
    public Transform leftSpawn;
    public Transform rightSpawn;

    [HideInInspector]
    public GameObject firedProjectile;
    public IShootable leftBullet;
    public IShootable rightBullet;

    private void Awake()
    {
        character.SetBehaviour();
    }
    void Start()
    {
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
        if (Input.GetButton("LeftArm"))
        {
            ShootProjectile(leftBullet, leftSpawn);
        }
        if (Input.GetButton("RightArm"))
        {
            ShootProjectile(rightBullet, rightSpawn);
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

    public void ShootProjectile(IShootable shootable, Transform t)
    {
        character.projectileSpawn = t;
        firedProjectile = Instantiate(shootable.shootableObject, character.projectileSpawn.position, character.projectileSpawn.rotation);
        firedProjectile.transform.forward = character.projectileSpawn.forward;
        firedProjectile.AddComponent<ProjectileBehavior>();
        firedProjectile.GetComponent<ProjectileBehavior>().SetOwner(character);
        firedProjectile.AddComponent<Rigidbody>().velocity += gameObject.transform.forward * character.projectileSpeed;
        Destroy(firedProjectile, 2f);
    }
    public Setnums()
    {

    }
}
