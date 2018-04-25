using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Character")]
public class Character : ScriptableObject, IDamageable, IDamager, IShooter
{
    public List<Part> parts;    //  List of Character Parts
    void OnEnable() 
    {
        parts = new List<Part>() { Left, Right, LegSet, HeadPiece };    // New up List of Character Parts
    }

    public Part Left;   //  Left Arm Part
    public Part Right;  //  Right Arm Part
    public Part LegSet; //  Legs Part
    public Part HeadPiece;  //  Head Part
    public string Name; //  Name for character (EX: Player 1 or P1)
    public float Health { get; set; }  //  Set health for character
    public int DashCharges; //  Dashes avalible for character
    public float Speed; //  Default speed for the character
    public float DashSpeed; //  Default dash speed for the character
    public float Damage { get; set; } // Damage that will be inflicted to another character
    public Vector3 StartingPos; //  Position Character Starts in a given scene
    public bool isDead; // Boolean that determines whether the player is "Dead".
    public float projectileSpeed { get; set; }
    public Transform projectileSpawn { get; set; }

    public ArmBehaviour LeftArmBehaviour;
    public ArmBehaviour RightArmBehaviour;
    public HeadBehaviour HeadBehaviour;

    public void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(Damage);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
    }


    public void SetBehaviour()
    {
        var go = new GameObject();
        var la = go.AddComponent<ArmBehaviour>();
        var ra = go.AddComponent<ArmBehaviour>();
        var h = go.AddComponent<HeadBehaviour>();
        LeftArmBehaviour = la;
        RightArmBehaviour = ra;
        HeadBehaviour = h;
    }
    public void SetArms(GameObject lo, GameObject ro)
    {
        LeftArmBehaviour.ArmConfig = Left as Arm;
        LeftArmBehaviour.SetProjectile(lo);
        RightArmBehaviour.ArmConfig = Right as Arm;
        RightArmBehaviour.SetProjectile(ro);
    }
}
