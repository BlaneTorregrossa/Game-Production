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
        var cd = go.GetComponent<Collider>();
        cd.isTrigger = true;
        var ex = go.GetComponent<ExplosionBehaviour>();
        if(ex == null)
        {
            ex = go.AddComponent<ExplosionBehaviour>();
        }
        ex.Explosion(Damager, 3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Damager == null)
        {
            return;
        }
        else
        {
            Explode(Explosion);
        }
    }
}
