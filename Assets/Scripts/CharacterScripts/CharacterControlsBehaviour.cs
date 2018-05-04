using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  *** Issue: Needs to be ready for multiple controllers + needs Menu navigation controls (Pause and Character Customization)
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
    public bool _paused;    //  if game is "Paused"

    [SerializeField]
    GameLoopBehaviour GameLoopInstance; //  For a boolen to disable controls while wait timer is running if in PVP mode
    private Vector3 _movedirection;
    private Vector3 _lookdirection;
    private Vector3 _dashdirection;
    private Quaternion _currentrot;
    private GameObject _object;
    private GameType.GameMode _mode;
    private bool _wait;

    // Use this for initialization
    void Start()
    {
        _canmove = true;
        _dashing = false;
        _paused = false;    //  paused must always start disabled
        _dashtime = 0;
        _charges = Characterconfig.DashCharges;
    }

    private void FixedUpdate()
    {
        _mode = GameLoopInstance.CurrentGameMode;
        _wait = GameLoopInstance.WaitForTimer;

        #region Joystick1
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 0)
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

        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 0)
        {
            //   For Menu Controls
        }
        #endregion

        #region Joystick2
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 1)
        {
            _lookdirection = new Vector3(Input.GetAxis("LookHorizontalB"), 0, Input.GetAxis("LookVerticalB"));
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

        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 1)
        {
            //   For Menu Controls
        }
        #endregion

    }

    // Update is called once per frame
    void Update()
    {

        _mode = GameLoopInstance.CurrentGameMode;
        _wait = GameLoopInstance.WaitForTimer;
        
        #region Joystick 1
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 0)
        {

            if (Input.GetButtonDown("Pause"))   //  Pause button
            {
                if (_paused == false)
                    _paused = true;
                else if (_paused == true)
                    _paused = false;
            }

            if (Input.GetAxis("LeftArm") >= 1 && _paused == false)
            {
                Debug.Log("Left Arm Attack not present!");
            }

            if (Input.GetAxis("RightArm") >= 1 && _paused == false)
            {
                Debug.Log("Right Arm Attack not present!");
            }

            if (Input.GetButtonDown("Head") && _paused == false)
            {
                Debug.Log("Head Abillity not present!");
            }

            if (Input.GetButtonDown("Dash") && _dashing == false && _paused == false)   //  Dash Button
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

        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 0)
        {
            //   For Menu Controls
        }
        #endregion

        #region Joystick2
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 0)
        {

            if (Input.GetButtonDown("PauseB"))   //  Pause button
            {
                if (_paused == false)
                    _paused = true;
                else if (_paused == true)
                    _paused = false;
            }

            if (Input.GetAxis("LeftArmB") >= 1 && _paused == false)
            {
                Debug.Log("Left Arm Attack not present!");
            }

            if (Input.GetAxis("RightArmB") >= 1 && _paused == false)
            {
                Debug.Log("Right Arm Attack not present!");
            }

            if (Input.GetButtonDown("HeadB") && _paused == false)
            {
                Debug.Log("Head Abillity not present!");
            }

            if (Input.GetButtonDown("DashB") && _dashing == false && _paused == false)   //  Dash Button
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

        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 0)
        {
            //   For Menu Controls
        }
        #endregion
    }

    //Returns a 3D Vector based axis based off the axis produced by the left analog stick/WASD keys
    void Move(float s)
    {
        float x = 0;
        float z = 0;

        if (Controllerconfig.gamePadNum == 0)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        if (Controllerconfig.gamePadNum == 1)
        {
            x = Input.GetAxis("HorizontalB");
            z = Input.GetAxis("VerticalB");
        }

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