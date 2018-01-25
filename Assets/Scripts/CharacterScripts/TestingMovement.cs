using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMovement : MonoBehaviour
{
    public float Speed;

	// Update is called once per frame
	void Update ()
    {
        var x = Input.GetAxis("Horizontal") * Speed;
        var z = Input.GetAxis("Vertical") * Speed;
        transform.position += new Vector3(x, 0, z);
	}
}
