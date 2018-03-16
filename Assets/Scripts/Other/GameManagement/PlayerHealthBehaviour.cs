using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public FloatVariable health;
	// Use this for initialization
	void Start ()
    {
        health.Value = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("space"))
        {
            health.Value -= 5;
        }
	}
}
