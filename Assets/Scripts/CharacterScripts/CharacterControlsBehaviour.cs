using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Characterconfig;
    public CharacterControls Controllerconfig;

    private GameObject _object;
    public bool _dashing;
    public int _dashtime;

    // Use this for initialization
    void Start()
    {
        _dashing = false;
        _dashtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LeftArm"))
        {
            LeftArmAttack();
        }

        if (Input.GetButtonDown("RightArm"))
        {
            RightArmAttack();
        }

        if (Input.GetButtonDown("Head"))
        {
            HeadActivate();
        }

        if (Input.GetButtonDown("Dash"))
        {
            _dashing = true;
            Debug.Log("Dash!");
        }

        if (_dashing)
        {
            transform.position += Move(Characterconfig.DashSpeed);
            _dashtime += 1;
            if (_dashtime >= 30)
            {
                _dashing = false;
                _dashtime = 0;
                Debug.Log("Stopped Dashing!");
            }
        }
        transform.position += Move(Characterconfig.Speed);
        /*Determines the rotation of the Character in regards to the result of the direction
        that the arrow keys/right analog stick ar being held*/
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(Look()), Time.deltaTime);
    }

    //Returns a 3D Vector based axis based off the axis produced by the left analog stick/WASD keys
    Vector3 Move(float s)
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var m = new Vector3(x, 0, z) * s;
        return m;
    }

    //Create a Dash Function that takes away the player's control and makes them

    /*Returns a normalized 3D Vector based off the axis produced by the 
    right analog stick/arrow keys*/
    Vector3 Look()
    {
        //Currently only turns slowly. Need to change it so that the player snaps to the given direction.
        var x = Input.GetAxis("LookHorizontal");
        var z = Input.GetAxis("LookVertical");
        var r = new Vector3(x, 0, z);
        return r.normalized;
    }

    //Performs the Left Arm Attack when called
    void LeftArmAttack()
    {
        Debug.Log("Attacked with Left Arm!");
    }

    //Performs the Right Arm Attack when called
    void RightArmAttack()
    {
        Debug.Log("Attacked with Right Arm!");
    }

    //Performs the Head ability when called
    void HeadActivate()
    {
        Debug.Log("Used Head Ability!");
    }
}