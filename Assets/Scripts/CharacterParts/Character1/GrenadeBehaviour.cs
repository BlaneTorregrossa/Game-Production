using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public Grenade GrenadeConfig;

    private float _distanceTraveled;
    private GameObject _explosionObject;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Falloff()
    {
        if (_distanceTraveled == GrenadeConfig.Distance)
        {
            CreateExplosion();
        }
    }
    
    public void CreateExplosion()
    {
        
    }
}
