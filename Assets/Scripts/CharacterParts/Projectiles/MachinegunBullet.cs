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

    public override void Shoot(Transform ownerTransform, Transform positionTransform, IDamager damager, float projectileSpeed)
    {
        if (Cooldown < _coolDownStart)
        {
            ownerTransform.GetComponent<MonoBehaviour>().StartCoroutine(StartCountdown());
            return;
        }
        var firedProjectile = Instantiate(prefab, positionTransform.position, positionTransform.rotation);
        firedProjectile.transform.forward = positionTransform.forward;
        var pb = firedProjectile.GetComponent<ProjectileBehaviour>();
        if (pb == null)
        { 
            pb = firedProjectile.AddComponent<ProjectileBehaviour>();
        }
        pb.SetShooter(damager);
        pb.SetOwner(ownerTransform.GetComponent<CharacterBehaviour>());

        var rb = firedProjectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = firedProjectile.AddComponent<Rigidbody>();
        }
        rb.velocity += ownerTransform.transform.forward * projectileSpeed;
        Destroy(firedProjectile, 1);

        ownerTransform.GetComponent<MonoBehaviour>().StartCoroutine(StartCountdown());
    }
    
}
