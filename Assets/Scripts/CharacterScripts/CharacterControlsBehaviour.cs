using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Character;
    public CharacterControls Controller;

    private GameObject _object;
    private Vector3 _look;
    private bool _dashing;

	// Use this for initialization
	void Start ()
    {
        _dashing = false;
	}
    
    // Update is called once per frame
    void Update ()
    {
        
        if(!_dashing)
        {
            transform.position += Move() * Character.Speed;
        }
        else
        {
            transform.position += Dash() * Character.DashSpeed;
        }
	}

    Vector3 Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var m = new Vector3(x, 0, z);
        return m;
    }
    Vector3 Dash()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var d = new Vector3(x, 0, z);
        return d;
    }

}