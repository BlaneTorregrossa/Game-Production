using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/MachineGunBullet")]
public class MachinegunBullet : Projectile
{    

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
        var pb = firedProjectile.GetComponent<ProjectileBehaviour>();
        if (pb == null)
            pb = firedProjectile.AddComponent<ProjectileBehaviour>();
        pb.SetOwner(damager);
        var rb = firedProjectile.GetComponent<Rigidbody>();
        if (rb == null)
            rb = firedProjectile.AddComponent<Rigidbody>();
        rb.velocity += ownerTransform.transform.forward * projectileSpeed;
        Destroy(firedProjectile, 1);

        ownerTransform.GetComponent<MonoBehaviour>().StartCoroutine(StartCountdown());
    }
    
}
