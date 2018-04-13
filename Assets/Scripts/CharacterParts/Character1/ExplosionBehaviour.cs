using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float Damage;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {

        }
    }

    public void ExplosionEnd()
    {

    }
}
