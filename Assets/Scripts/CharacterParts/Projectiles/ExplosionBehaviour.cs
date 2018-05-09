using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour, IExplode
{
    public IDamager _owner;

    public void Explode(IDamager Damager, float Duration)
    {
        
    }
}
