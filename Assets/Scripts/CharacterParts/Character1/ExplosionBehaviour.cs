using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 2f);
    }

    private Character _shooter;

    public void OnTriggerEnter(Collider other)
    {
        if(_shooter == null)
        {
            return;
        }
        if(other.tag == "Character")
        {
            _shooter.DoDamage(other.GetComponent<CharacterBehaviour>().character);
        }
    }
    public void SetOwner(Character owner)
    {
        _shooter = owner;
    }
}
