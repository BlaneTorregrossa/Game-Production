﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{
    public Character characterConfig;
    public GameObject projectileObject;
    public MachineGunBulletBehaviour machineGunBulletBehaviour;
    public GrenadeBehaviour grenadeBehaviour;
    public Transform location;
    public bool rapidFire;

    [HideInInspector]
    public GameObject firedProjectile;
    
    private void FixedUpdate()
    {
        if(Input.GetKey("space"))
        {
            FireMachineGunBullet();
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
}