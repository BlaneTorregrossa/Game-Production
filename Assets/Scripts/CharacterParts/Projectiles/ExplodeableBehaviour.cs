using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeableBehaviour : MonoBehaviour, IExplodeable
{
    public GameObject Explosion;
    public IDamager Damager;

    public void Explode(GameObject Object)
    {
        var go = Instantiate(Object);
        var ex = go.GetComponent<ExplosionBehaviour>();
        if(ex == null)
        {
            ex = go.AddComponent<ExplosionBehaviour>();
        }
        Destroy(gameObject);
    }
    

}
