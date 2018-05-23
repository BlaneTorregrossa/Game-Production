using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Grenade")]
public class Grenade : Projectile
{
    public GameObject ExplosionObject;
    public float Duration;
    public float Radius;

    private void OnEnable()
    {
        _coolDownStart = Cooldown;
    }

    public override void Shoot(Transform ownerTransform, Transform positionTransform, IDamager damager, float projectileSpeed)
    {
        if (Cooldown < _coolDownStart)
            return;
        var firedProjectile = Instantiate(prefab, positionTransform.position, positionTransform.rotation);
        firedProjectile.transform.forward = positionTransform.forward;
        var projectileBehaviour = firedProjectile.AddComponent<ProjectileBehaviour>();
        projectileBehaviour.SetShooter(damager);
        var pb = firedProjectile.GetComponent<ProjectileBehaviour>();
        if (pb == null)
        {
            pb = firedProjectile.AddComponent<ProjectileBehaviour>();
        }
        pb.SetShooter(damager);
        pb.SetOwner(ownerTransform.GetComponent<CharacterBehaviour>());

        var eb = firedProjectile.GetComponent<ExplodeableBehaviour>();
        if (eb == null)
        {
            eb = firedProjectile.AddComponent<ExplodeableBehaviour>();
        }
        eb.Explosion = ExplosionObject;
        eb._radius = Radius;
        eb._duration = Duration;
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
