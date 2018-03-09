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
        _object = new GameObject();
        _object.name = "Test";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            addobjecttoList(_object);
        }
    }

    public void addobjecttoList(GameObject g)
    {
        objects.Add(g);
        Debug.Log("Object was added");
    }
}