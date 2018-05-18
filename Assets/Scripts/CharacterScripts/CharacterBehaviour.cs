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
    public IDamager leftdamager { get { return character.Left as Arm; } }
    public IFireable rightArm { get { return character.Right as Arm; } }
    public IDamager rightdamager { get { return character.Right as Arm; } }

    void Start()
    {         
        characterHealth = 100;
        character.Health = characterHealth;
        character.isDead = (character.Health <= 0);
        SetCharacterSpeed(character.LegSet as Legs);
    }

    void Update()
    {
        character.isDead = (character.Health <= 0);
        gameObject.SetActive(!character.isDead);
    }
    public void SetCharacterSpeed(Legs legs)
    {
        character.Speed = legs.Speed;
        character.DashSpeed = legs.DashSpeed;
        character.DashCharges = legs.DashCharges;
    }

    // Resets character Health and the Countdown for both projectiles on both arms
    public void ResetCharacter()
    {
        var left = character.Left as Arm;
        var right = character.Right as Arm;
        character.Health = characterHealth;
        character.isDead = false;
        left.projectile.ResetCountdown();
        right.projectile.ResetCountdown();
        character.Left = left;
        character.Right = right;
    }
}
