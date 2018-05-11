using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeableBehaviour : MonoBehaviour, IExplodeable
{
    public GameObject Explosion;
    public IDamager Damager;
    public float _duration;
    public float _radius;

    public void Explode(GameObject Object)
    {
        var go = Instantiate(Object, gameObject.transform.position, gameObject.transform.rotation);
        go.transform.localScale = new Vector3(_radius, _radius, _radius);
        var cd = go.GetComponent<Collider>();
        if (cd == null)
        {
            cd = go.AddComponent<Collider>();
        }
        cd.isTrigger = true;
        var ex = go.GetComponent<ExplosionBehaviour>();
        if (ex == null)
        {
            ex = go.AddComponent<ExplosionBehaviour>();
        }
        ex.Explosion(Damager, _duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Damager == null)
        {
            return;
        }
        if (other.tag == "Target")
        {
            Explode(Explosion);
        }
        if (other.tag == "Character")
        {
            Explode(Explosion);
        }
        if (other.tag == "Enviornment")
        {
            Explode(Explosion);
        }
    }
}
