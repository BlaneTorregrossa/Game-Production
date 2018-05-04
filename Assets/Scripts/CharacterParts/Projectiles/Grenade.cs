using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Grenade")]
public class Grenade : Projectile, IExplode
{
    public GameObject GameObject;

    //creates the explosion which needs an IDamager to calculate the damage of the explosion
    public void Explode(GameObject Object)
    {
        var explosion = Instantiate(Object);
    }

    public override void Shoot(Transform ownerTransform, IDamager damager, float projectileSpeed)
    {
        if (Cooldown < _coolDownStart)
            return;
        var firedProjectile = Instantiate(prefab, ownerTransform.position, ownerTransform.rotation);
        firedProjectile.transform.forward = ownerTransform.forward;
        var projectileBehaviour = firedProjectile.AddComponent<ProjectileBehaviour>();
        projectileBehaviour.SetOwner(damager);
        var rb = firedProjectile.GetComponent<Rigidbody>();
        if (rb == null)
            rb = firedProjectile.AddComponent<Rigidbody>();
        rb.velocity += ownerTransform.transform.forward * projectileSpeed;
        Destroy(firedProjectile, 2);

        ownerTransform.GetComponent<MonoBehaviour>().StartCoroutine(StartCountdown());
    }
    
}
