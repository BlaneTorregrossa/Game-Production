using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
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
        Vector3 m = d * s;
        return m;
    }

    public Vector3 DashMove(Vector3 d, float ds)
    {
        Vector3 m = d * ds;
        return m;
    }
}