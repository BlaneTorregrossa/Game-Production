using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =*=
public class ProjectileBehavior : MonoBehaviour
{

    public Projectile projectileInstance;

    // Very Temporary
    public SetUpCharacter character;

    void Start()
    {
        projectileInstance = new Projectile();
        projectileInstance.position = character.ArmObject.transform.position;
        projectileInstance.position += transform.forward * 4;
        tag = "Bullet";
    }

    void Update()
    {
        transform.position = projectileInstance.position;
        projectileInstance.position += transform.forward;
    }

}
