using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{
    public GameObject projectileObject;
    public MachineGunBulletBehaviour machineGunBulletBehaviour;
    GrenadeBehaviour grenadeBehaviour;
    public Transform location;
    public bool rapidFire;

    [HideInInspector]
    public GameObject firedProjectile;
    
    private void Update()
    {
        if(Input.GetKey("space"))
        {
            FireProjectile(machineGunBulletBehaviour);
        }
    }

    public void FireProjectile(Behaviour bulletBehaviour)
    {
        firedProjectile = Instantiate(projectileObject, location.position, transform.rotation);
        firedProjectile.transform.forward = transform.forward;
        firedProjectile.GetComponent<MachineGunBulletBehaviour>();
        firedProjectile.GetComponent<Rigidbody>().velocity += gameObject.transform.forward * firedProjectile.GetComponent<MachineGunBulletBehaviour>().BulletConfig.speed;
        Destroy(firedProjectile, 5f);
    }
}