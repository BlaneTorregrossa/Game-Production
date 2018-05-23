using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Breakable/Crate")]
public class Crate : ScriptableObject, IDamageable
{
    public float Durability;
    public float MaxDurability;
    
    public void TakeDamage(float amount)
    {
        Durability -= amount;
    }
}
