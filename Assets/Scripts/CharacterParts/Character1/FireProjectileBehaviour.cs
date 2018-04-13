﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{
    public Character characterConfig;
    public GameObject projectileObject;
    public Transform location;
    public bool rapidFire;

    private int _reloadTime;
    private int _shotTime;

    [HideInInspector]
    public GameObject firedProjectile;
    
    private void Start()
    {
        _reloadTime = 0;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("space") && rapidFire == true)
        {
            _shotTime += 1;
            FireMachineGunBullet();
        }
        if (Input.GetKey("space") && rapidFire == false)
        {
            if (_reloadTime == 0)
            {
                FireGrenade();
                _reloadTime = 100;
            }
        }
        if(_reloadTime > 0)
        {
            _reloadTime -= 1;
        }
    }

    public void FireMachineGunBullet()
    {
        if (_shotTime == 5)
        {
            firedProjectile = Instantiate(projectileObject, location.position, transform.rotation);
            firedProjectile.transform.forward = transform.forward;
            firedProjectile.GetComponent<ProjectileBehavior>().SetOwner(characterConfig);
            firedProjectile.GetComponent<Rigidbody>().velocity += gameObject.transform.forward * firedProjectile.GetComponent<MachineGunBulletBehaviour>().BulletConfig.speed;
            Destroy(firedProjectile, 2f);
            _shotTime = 0;
        }
    }

    public void FireGrenade()
    {

    }
}