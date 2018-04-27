using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Characterconfig;
    public CharacterControls Controllerconfig;
    public int _charges;
    public int _recharge;
    public bool _canmove;
    public bool _dashing;
    public int _dashtime;
    public int _dashduration;
    
    private Vector3 _movedirection;
    private Vector3 _lookdirection;
    private Vector3 _dashdirection;
    private Quaternion _currentrot;
    private GameObject _object;

    // Use this for initialization
    void Start()
    {
        _canmove = true;
        _dashing = false;
        _dashtime = 0;
        _charges = Characterconfig.DashCharges;
    }

    private void FixedUpdate()
    {
        _lookdirection = new Vector3(Input.GetAxis("LookHorizontal"), 0, Input.GetAxis("LookVertical"));
        if (_dashing)
        {
            Dash(Characterconfig.DashSpeed, _dashtime, _dashdirection);
        }
        if (_canmove)
        {
            Move(Characterconfig.Speed);
        }

        transform.rotation = Look(transform.rotation, _lookdirection, 5);
    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetButtonDown("Dash") && _dashing == false)
        {
            if (_charges >= 0)
            {
                _dashing = true;
                _dashtime = _dashduration;
                _canmove = false;
                _charges -= 1;
                Debug.Log("Started Dash, -1 Dash Charge");
            }
            else
            {
                Debug.Log("Not enough charges");
            }
        }
        DashRecharge(200, Characterconfig.DashCharges);
    }

    //Returns a 3D Vector based axis based off the axis produced by the left analog stick/WASD keys
    void Move(float s)
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        _movedirection = new Vector3(x, 0, z);
        _dashdirection = _movedirection;
        var m = _movedirection * s;
        transform.position += m;
    }

    void Dash(float speed, int count, Vector3 Direction)
    {
        Vector3 move = Direction * speed;
        _dashtime -= 1;
        transform.position += move;
        if (count == 0)
        {
            _dashing = false;
            _canmove = true;
        }
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
    
    void DashRecharge(int rechargenum, int limit)
    {
        if (_recharge >= rechargenum && _charges != limit)
        {
            _charges += 1;
            _recharge = 0;
        }
        else
        {
            _recharge += 1;
        }
    }
}