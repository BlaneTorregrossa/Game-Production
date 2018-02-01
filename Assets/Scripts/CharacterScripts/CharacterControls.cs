using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public Character CharacterConfig;

    private MovementBehaviour _movement;
    private Vector3 _lookdirection;
    
	// Use this for initialization
	void Start ()
    {
        var go = new GameObject();
        go.name = "Movement";
        _movement = go.AddComponent<MovementBehaviour>();
        _movement.speed = CharacterConfig.Speed;
        _movement.dashSpeed = CharacterConfig.DashSpeed;
        _movement.dashcharges = CharacterConfig.DashCharges;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var x = Input.GetAxis("Horizontal") * _movement.speed;
        var z = Input.GetAxis("Vertical")  * _movement.speed;
        Look();
        _movement.direction = new Vector3(x, 0, z);
	}
    public void Look()
    {
        var lx = Input.GetAxis("LookHorizontal");
        var lz = Input.GetAxis("LookVertical");
        _lookdirection = new Vector3(lx, 0, lz);
    }
}
