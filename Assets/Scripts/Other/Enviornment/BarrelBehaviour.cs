using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour, IExplodeable
{
    public Barrel BarrelConfig;
    public GameObject ExplosionObject;
    public float Radius;
    public float Duration;

    public void Explode(GameObject Object)
    {
        var go = Instantiate(Object, gameObject.transform.position, gameObject.transform.rotation);
        go.transform.localScale = new Vector3(Radius, Radius, Radius);
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
        ex.Explosion(BarrelConfig, Duration);
        Destroy(gameObject);
    }

    public void ResetDurability()
    {
        BarrelConfig.Durability = BarrelConfig.MaxDurability;
    }

    void Start()
    {
        ResetDurability();
    }

    // Update is called once per frame
    void Update ()
    {
		if(BarrelConfig.Durability <= 0)
        {
            Explode(ExplosionObject);
        }
	}
}
