using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Character;
    public CharacterControls Controller;

    private MovementBehaviour _movement;
    private Vector3 _move;
    private Vector3 _dash;
    private Vector3 _look;
    private bool _dashing;

	// Use this for initialization
	void Start ()
    {
        _dashing = false;
        var o = new GameObject();
        _movement = o.AddComponent<MovementBehaviour>();
	}
    
    // Update is called once per frame
    void Update ()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        _move = _movement.BasicMove(Controller.moveDirection, Character.Speed);
        _dash = _movement.DashMove(Controller.dashDirection, Character.DashSpeed);
        _look = Controller.lookDirection;

        if(!_dashing)
        {
            transform.position += _move;
        }
        else
        {
            transform.position += _dash;
        }
	}
}