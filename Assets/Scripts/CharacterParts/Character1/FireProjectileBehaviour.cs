using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{
    public Character characterConfig;
    public GameObject projectileObject;
    public Transform location;
    public bool rapidFire;

    [HideInInspector]
    public GameObject firedProjectile;
    
    private void FixedUpdate()
    {
        if(Input.GetKey("space") && rapidFire == true)
        {
            FireMachineGunBullet();
        }
        if(Input.GetKey("space") && rapidFire == false)
        {
            FireGrenade();
        }
    }

    public void FireMachineGunBullet()
    {
        firedProjectile = Instantiate(projectileObject, location.position, transform.rotation);
        firedProjectile.transform.forward = transform.forward;
        firedProjectile.GetComponent<ProjectileBehavior>().SetOwner(characterConfig);
        firedProjectile.GetComponent<Rigidbody>().velocity += gameObject.transform.forward * firedProjectile.GetComponent<MachineGunBulletBehaviour>().BulletConfig.speed;
        Destroy(firedProjectile, 2f);
    }

    public void FireGrenade()
    {

    }
}