using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Character;
    public CharacterControls Controller;

    private GameObject _object;
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
            transform.position += Move() * Character.DashSpeed;
        }
        transform.rotation = new Quaternion(0, Look(), 0, 1);
	}

    Vector3 Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var m = new Vector3(x, 0, z);
        return m;
    }

    float Look()
    {
        var x = Input.GetAxis("LookHorizontal");
        var z = Input.GetAxis("LookVertical");
        var y = x + z;
        return y;
    }

    void LeftArmAttack()
    {

    }

    void RightArmAttack()
    {

    }

    void HeadActivate()
    {

    }
}