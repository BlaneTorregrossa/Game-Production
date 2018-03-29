using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =*=
public class ProjectileBehavior : MonoBehaviour
{
    public Projectile projectileConfig;
    
    private Character _shooter;
    private bool _hit;
    
    public void SetOwner(Character owner)
    {
        _shooter = owner;
    }

    public bool CheckforHit(string inputTag)
    {
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_shooter == null)
        {
            return;
        }
        if (other.tag == "Character")
        {
            InflictDamage(other.GetComponent<CharacterBehaviour>());
        }
    }

    public void InflictDamage(CharacterBehaviour character)
    {
        character.TakeDamage(projectileConfig.damage);
        Destroy(gameObject);
    }
}
