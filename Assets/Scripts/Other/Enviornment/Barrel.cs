using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Breakable/Barrel")]
public class Barrel : ScriptableObject, IDamageable, IDamager
{
    public float Damage;
    public float Durability;
    public float MaxDurability;

    public void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(Damage);
    }

    public void TakeDamage(float amount)
    {
        Durability -= amount;
    }
    
}
