using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{
    public GameObject projectileObject;
    public Transform location;
    public MachineGunBulletBehaviour machineGunBulletBehaviour;

    [HideInInspector]
    public GameObject firedProjectile;

    private void Start()
    {
        machineGunBulletBehaviour = projectileObject.AddComponent<MachineGunBulletBehaviour>();
    }

    public void FireProjectile(Behaviour bulletBehaviour)
    {
        firedProjectile = Instantiate(projectileObject, location.position, transform.localRotation);
        firedProjectile.GetComponent<MachineGunBulletBehaviour>();

        Destroy(firedProjectile, 5f);
    }
}
