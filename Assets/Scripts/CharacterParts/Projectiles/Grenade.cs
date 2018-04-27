using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Grenade")]
public class Grenade : Projectile
{
    public float Distance;
    public float Radius;

    public override void Shoot(Transform ownerTransform, float projectileSpeed)
    {
        if (Cooldown < _coolDownStart)
            return;
        var firedProjectile = Instantiate(prefab, ownerTransform.position, ownerTransform.rotation);
        firedProjectile.transform.forward = ownerTransform.forward;
        var projectileBehaviour = firedProjectile.AddComponent<ProjectileBehaviour>();
        var rb = firedProjectile.GetComponent<Rigidbody>();
        if (rb == null)
            rb = firedProjectile.AddComponent<Rigidbody>();
        rb.velocity += ownerTransform.transform.forward * projectileSpeed;
        Destroy(firedProjectile, 1);

        ownerTransform.GetComponent<MonoBehaviour>().StartCoroutine(StartCountdown());
    }
}
