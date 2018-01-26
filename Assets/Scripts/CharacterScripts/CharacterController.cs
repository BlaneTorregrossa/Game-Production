using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Character CharacterConfig;

    private MovementBehaviour _movement;
    
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
		
	}

    void ApplyMovement()
    {

    }
}
