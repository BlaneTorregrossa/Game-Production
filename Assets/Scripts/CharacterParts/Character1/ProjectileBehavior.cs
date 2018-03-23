using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =*=
public class ProjectileBehavior : MonoBehaviour
{
    public Projectile projectileInstance;

    private Character _shooter;
    private bool _hit;

    void Start()
    {
        
    }

    void Update()
    {
        _hit = CheckforHit(projectileInstance.tag);
        if(_hit)
        {
            InflictDamage();
            Destroy(gameObject);
        }
    }
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
        if (_shooter = null)
        {
            return;
        }
        if (other.tag == "Character")
        {
            InflictDamage(other.GetComponent<CharacterBehaviour>().character);
        }
    }
    public void InflictDamage(Character character)
    {

    }
}
