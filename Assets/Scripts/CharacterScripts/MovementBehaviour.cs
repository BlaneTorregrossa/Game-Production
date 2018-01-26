using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public int dashcharges;
    public bool dash;
    public Vector3 direction;
    public Vector3 dashDirection;

    private float _acceleration;
    private float _velocity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * speed;
        direction.z = Input.GetAxis("Vertical") * speed;
        dashDirection.x = Input.GetAxis("Horizontal") * dashSpeed;
        dashDirection.z = Input.GetAxis("Vertical") * dashSpeed;
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
            BasicMove(dashDirection);
        }
        else
        {
            BasicMove(direction);
        }
    }

    void BasicMove(Vector3 d)
    {
        transform.position += d;
    }
}