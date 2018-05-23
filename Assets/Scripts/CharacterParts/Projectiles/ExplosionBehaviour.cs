using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour, IExplode
{
    public IDamager _owner;

    public void Explosion(IDamager Damager, float Duration)
    {
        _owner = Damager;
        Destroy(gameObject, Duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_owner == null)
        {
            return;
        }
        if(other.tag == "Target")
        {
            _owner.DoDamage(other.GetComponent<TargetBehaviour>().TargetConfig);
        }
        if (other.tag == "Character")
        {
            _owner.DoDamage(other.GetComponent<CharacterBehaviour>().character);
        }
    }
}