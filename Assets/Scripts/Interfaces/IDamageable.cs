using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float amount);
}

public interface IDamager
{
    void DoDamage(IDamageable damageable);
    float Damage { get; set; }
}