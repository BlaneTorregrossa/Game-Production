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
        firedProjectile = Instantiate(projectileObject, location.position, transform.rotation);
        firedProjectile.transform.forward = transform.forward;
        firedProjectile.GetComponent<MachineGunBulletBehaviour>();
        Destroy(firedProjectile, 5f);
    }
}
