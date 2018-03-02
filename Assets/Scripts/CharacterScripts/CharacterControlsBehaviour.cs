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
        transform.rotation = new Quaternion(0, Look(), 0, 1);
    }

    //Returns a 3D Vector based axis returned by the analog stick/WASD keys
    Vector3 Move(float s)
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var m = new Vector3(x, 0, z) * s;
        return m;
    }

    //Returns a float that is meant to represent the Y rotation of the character
    float Look()
    {
        //Problem: Currently only looks in 180 degrees
        //Likely Cause: y most like always equal a total that brings it to the 180 degree range that it's currently looking in.
        var x = Input.GetAxis("LookHorizontal");
        var z = Input.GetAxis("LookVertical");
        var y = x + z;
        return y;
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