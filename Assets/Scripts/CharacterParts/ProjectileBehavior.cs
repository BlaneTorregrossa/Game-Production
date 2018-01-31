using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public Projectile projectileInstance;

    // Very Temporary
    public SetUpArm character;

    void Start()
    {
        projectileInstance = new Projectile();
        projectileInstance.position = character.ArmObject.transform.position;
        projectileInstance.position += transform.forward;
    }

    void Update()
    {
        transform.position = projectileInstance.position;
        projectileInstance.position += transform.forward;
    }

}
