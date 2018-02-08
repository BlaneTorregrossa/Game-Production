using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmupFunctions : MonoBehaviour
{
    public List<GameObject> objects;

    private GameObject _object;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void addobjecttoList(GameObject g)
    {
        objects.Add(g);
        Debug.Log("Object was added")
    }
}
