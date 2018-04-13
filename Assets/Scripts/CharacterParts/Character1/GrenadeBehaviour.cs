using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public Grenade grenadeConfig;
    public Character characterConfig;
    public GameObject explosionObject;
    
    [HideInInspector]
    public GameObject _explosionObject;

    //[SerializeField]
    //private Vector3 _startingLocation;

    //private void Update()
    //{
    //    if(Falloff())
    //    {
    //        CreateExplosion();
    //    }
    //}

    //public bool Falloff()
    //{


    //    return false;
    //}
    
    public void CreateExplosion()
    {
        _explosionObject = Instantiate(explosionObject);
        _explosionObject.transform.position = gameObject.transform.position;
        _explosionObject.transform.localScale = new Vector3(grenadeConfig.Radius, grenadeConfig.Radius, grenadeConfig.Radius);
        _explosionObject.GetComponent<ExplosionBehaviour>().SetOwner(characterConfig);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            CreateExplosion();
        }
    }
}
