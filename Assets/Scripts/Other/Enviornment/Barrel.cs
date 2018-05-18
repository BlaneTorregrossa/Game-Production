using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : ScriptableObject, IDamageable, IDamager
{
    public GameObject ExplosionObject;
    public float Damage;
    public float Durrability;

    public void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(Damage);
    }

    public void TakeDamage(float amount)
    {
        Durrability -= amount;
    }
    
}
