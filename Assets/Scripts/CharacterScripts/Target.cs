using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Target")]
public class Target : ScriptableObject, IDamageable
{
    public float Health;
    public bool Dead;

    public void TakeDamage(float amount)
    {
        Health -= amount;
    }
    
}
