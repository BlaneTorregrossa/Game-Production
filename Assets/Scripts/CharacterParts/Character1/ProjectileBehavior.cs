using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Projectile projectileConfig;
    
    private Character _shooter;
    
    public void SetOwner(Character owner)
    {
        _shooter = owner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_shooter == null)
        {
            return;
        }
        if (other.tag == "Character")
        {
            
            Destroy(gameObject);
        }
    }
    
}
