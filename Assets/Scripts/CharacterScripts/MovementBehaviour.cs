using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public bool dash;

    private Vector3 _direction;
    private float _acceleration;
    private float _velocity;

    // Use this for initialization
    void Start()
    {
        speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal") * speed;
        _direction.z = Input.GetAxis("Vertical") * speed;
        if (Input.GetKeyDown("space"))
        {
            dash = true;
        }
        BasicMove(_direction);

    }

    void BasicMove(Vector3 d)
    {
        if (dash)
        {
            
        }
        else
        {
            
        }
    }
}