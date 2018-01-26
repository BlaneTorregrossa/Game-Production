using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public int dashcharges;
    public bool dash;
    public Vector3 _direction;
    public Vector3 _dashDirection;

    private float _acceleration;
    private float _velocity;

    // Use this for initialization
    void Start()
    {
        speed = 0.2f;
        dashSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal") * speed;
        _direction.z = Input.GetAxis("Vertical") * speed;
        _dashDirection.x = Input.GetAxis("Horizontal") * dashSpeed;
        _dashDirection.z = Input.GetAxis("Vertical") * dashSpeed;
        if (Input.GetKeyDown("space"))
        {
            dash = true;
        }
        if (Input.GetKeyUp("space"))
        {
            dash = false;
        }
        if (dash)
        {
            BasicMove(_dashDirection);
        }
        else
        {
            BasicMove(_direction);
        }
    }

    void BasicMove(Vector3 d)
    {

        transform.position += d;
    }
}