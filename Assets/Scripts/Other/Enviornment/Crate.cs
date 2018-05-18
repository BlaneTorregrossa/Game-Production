using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : ScriptableObject, IDamageable
{
    public float Durability;
    
    public void TakeDamage(float amount)
    {
        Durability -= amount;
    }
}
