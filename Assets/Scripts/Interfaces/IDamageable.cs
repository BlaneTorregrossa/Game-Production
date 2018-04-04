using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Health { get; set; }
}

public interface IDamager
{
    void DoDamage(IDamageable damageable);
    float Damage { get; set; }
}