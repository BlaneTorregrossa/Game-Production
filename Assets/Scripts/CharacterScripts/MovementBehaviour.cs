using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
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

    }
    
    public Vector3 BasicMove(Vector3 d, float s)
    {
        var m = d * s;
        return m;
    }
}