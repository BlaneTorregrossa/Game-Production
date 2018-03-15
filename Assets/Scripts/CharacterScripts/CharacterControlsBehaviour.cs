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
        //Currently turns far more responsibly
        transform.localRotation = Look(transform.localRotation, Vector3.left);
    }

    //Returns a 3D Vector based axis based off the axis produced by the left analog stick/WASD keys
    Vector3 Move(float s)
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var m = new Vector3(x, 0, z) * s;
        return m;
    }

    //Create a Dash Function that takes away the player's control and changes their position based off the direction their control stick is being pushed in

    /*Returns a normalized 3D Vector based off the axis produced by the 
    right analog stick/arrow keys*/
    Quaternion Look(Quaternion l, Vector3 v)
    {
        if (v == Vector3.zero)
        {
            return new Quaternion(0,0,0,1);
        }
        Quaternion look = Quaternion.LookRotation(v);
        Quaternion r = Quaternion.Slerp(l, look, Time.deltaTime * 5);
        return r;
    }

    void Dash(float speed, Vector3 Direction)
    {

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