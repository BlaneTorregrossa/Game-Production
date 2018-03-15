using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Characterconfig;
    public CharacterControls Controllerconfig;
    public bool _dashing;
    public int _dashtime;

    private Vector3 _movedirection;
    private Vector3 _lookdirection;
    private Quaternion _currentrot;
    private GameObject _object;

    // Use this for initialization
    void Start()
    {
        _dashing = false;
        _dashtime = 0;
    }

    private void FixedUpdate()
    {
        _lookdirection = new Vector3 (Input.GetAxis("LookHorizontal"), 0, Input.GetAxis("LookVertical"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("LeftArm") > 0)
        {
            LeftArmAttack();
        }

        if (Input.GetAxis("RightArm") > 0)
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
            Dash(Characterconfig.DashSpeed, _movedirection);
        }
        transform.position += Move(Characterconfig.Speed);
        //transform.rotation = Look(transform.localRotation, _lookdirection);
        transform.rotation = Look(transform.rotation, _lookdirection, 5);
    }

    //Returns a 3D Vector based axis based off the axis produced by the left analog stick/WASD keys
    Vector3 Move(float s)
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var m = new Vector3(x, 0, z) * s;
        return m;
    }

    void Dash(float speed, Vector3 Direction)
    {

    }

    Quaternion Look(Quaternion l, Vector3 v, float s)
    {
        if (v == Vector3.zero)
        {
            return _currentrot;
        }
        Quaternion look = Quaternion.LookRotation(v);
        Quaternion r = Quaternion.Slerp(l, look, Time.deltaTime * s);
        _currentrot = r;
        return r;

        //var x = Input.GetAxis("LookHorizontal");
        //var z = Input.GetAxis("LookVertical");
        //var m = new Vector3(x, 0, z);
        //return m.normalized;
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