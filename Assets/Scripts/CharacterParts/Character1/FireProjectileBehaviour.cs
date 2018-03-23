using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{
    public GameObject projectileObject;
    public Transform location;
    public MachineGunBulletBehaviour machineGunBulletBehaviour;
    public float speed;

    [HideInInspector]
    public GameObject firedProjectile;
    
    private void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            FireProjectile(machineGunBulletBehaviour);
        }
    }

    public void FireProjectile(Behaviour bulletBehaviour)
    {
        firedProjectile = Instantiate(projectileObject, location.position, transform.localRotation);
        firedProjectile.GetComponent<MachineGunBulletBehaviour>();
        //firedProjectile.GetComponent<Rigidbody>().velocity += location.forward * speed;
        Destroy(firedProjectile, 5f);
    }
}
