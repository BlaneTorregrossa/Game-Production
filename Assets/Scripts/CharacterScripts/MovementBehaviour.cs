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
            BasicMove(direction);
    }
    
    void BasicMove(Vector3 d)
    {
        var move = d * Time.deltaTime;
        transform.position += move;
    }
}