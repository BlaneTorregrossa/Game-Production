using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Grenade")]
public class Grenade : Projectile
{
    public GameObject ExplosionObject;

    private void OnEnable()
    {
        _coolDownStart = Cooldown;
    }

    public override void Shoot(Transform ownerTransform, IDamager damager, float projectileSpeed)
    {
        if (Cooldown < _coolDownStart)
            return;
        var firedProjectile = Instantiate(prefab, ownerTransform.position, ownerTransform.rotation);
        firedProjectile.transform.forward = ownerTransform.forward;
        var projectileBehaviour = firedProjectile.AddComponent<ProjectileBehaviour>();
        projectileBehaviour.SetOwner(damager);
        var pb = firedProjectile.GetComponent<ProjectileBehaviour>();
        if (pb == null)
        {
            pb = firedProjectile.AddComponent<ProjectileBehaviour>();
        }
        pb.SetOwner(damager);
        
        var eb = firedProjectile.GetComponent<ExplodeableBehaviour>();
        if (eb == null)
        {
            eb = firedProjectile.AddComponent<ExplodeableBehaviour>();
        }
        eb.Explosion = ExplosionObject;
        eb.Damager = damager;

        var rb = firedProjectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = firedProjectile.AddComponent<Rigidbody>();
        }
        rb.velocity += ownerTransform.transform.forward * projectileSpeed;
        Destroy(firedProjectile, 2);

        ownerTransform.GetComponent<MonoBehaviour>().StartCoroutine(StartCountdown());
    }
    
}
