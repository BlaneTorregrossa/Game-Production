using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public GameObject DashProjectionObjectA, DashProjectionObjectB;
    public Character Characterconfig;
    public CharacterBehaviour Characterbehaviourconfig;
    public CharacterControls Controllerconfig;
    public int _charges;
    public int _recharge;
    public bool _canmove;
    public bool _dashing;
    public int _dashtime;
    public int _dashduration;
    public bool _checkReady;

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    GameLoopBehaviour GameLoopInstance; //  For a boolen to disable controls while wait timer is running if in PVP mode
    private Vector3 _movedirection;
    private Vector3 _lookdirection;
    private Vector3 _dashdirection;
    [SerializeField]
    private Vector3 _movementboundries;
    private Quaternion _currentrot;
    private GameType.GameMode _mode;
    private bool _wait;
    public string DashButtonValue = "Dash";
    public string DashBButtonValue = "DashB";

    // Use this for initialization
    void Start()
    {
        _canmove = true;
        _dashing = false;
        _checkReady = false;
        _dashtime = 0;
        _charges = Characterconfig.DashCharges;
        _animator = GetComponent<Animator>();
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
                DashProjection(Characterconfig.DashSpeed, _dashtime, _dashdirection);
            }
            if (_canmove)
            {
                Move(Characterconfig.Speed);
            }

            if (_lookdirection != new Vector3(0, 0, 0))
                transform.rotation = Look(transform.rotation, _lookdirection, 15);
            else
                transform.rotation = Look(transform.rotation, _movedirection, 15);

            #region Boundries
            if (transform.position.x > _movementboundries.x)
            {
                var XPos = _movementboundries.x - 1;
                transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -_movementboundries.x)
            {
                var XPos = -_movementboundries.x + 1;
                transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            }

            if (transform.position.y > _movementboundries.y)
            {
                var YPos = _movementboundries.y - 1;
                transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
            }
            else if (transform.position.y < -_movementboundries.y)
            {
                var YPos = -_movementboundries.y + 1;
                transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
            }

            if (transform.position.z > _movementboundries.z)
            {
                var ZPos = _movementboundries.z - 1;
                transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);
            }
            else if (transform.position.z < -_movementboundries.z)
            {
                var ZPos = -_movementboundries.z + 1;
                transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);
            }

            #endregion
        }
        #endregion

        #region Joystick2
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 1)
        {
            _lookdirection = new Vector3(Input.GetAxis("LookHorizontalB"), 0, Input.GetAxis("LookVerticalB"));
            if (_dashing)
            {
                DashProjection(Characterconfig.DashSpeed, _dashtime, _dashdirection);
            }
            if (_canmove)
            {
                Move(Characterconfig.Speed);
            }

            if (_lookdirection != new Vector3(0, 0, 0))
                transform.rotation = Look(transform.rotation, _lookdirection, 15);
            else
                transform.rotation = Look(transform.rotation, _movedirection, 15);

            #region Boundries
            if (transform.position.x > _movementboundries.x)
            {
                var XPos = _movementboundries.x - 1;
                transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -_movementboundries.x)
            {
                var XPos = -_movementboundries.x + 1;
                transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            }

            if (transform.position.y > _movementboundries.y)
            {
                var YPos = _movementboundries.y - 1;
                transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
            }
            else if (transform.position.y < -_movementboundries.y)
            {
                var YPos = -_movementboundries.y + 1;
                transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
            }

            if (transform.position.z > _movementboundries.z)
            {
                var ZPos = _movementboundries.z - 1;
                transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);
            }
            else if (transform.position.z < -_movementboundries.z)
            {
                var ZPos = -_movementboundries.z + 1;
                transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);
            }

            #endregion
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
            if (Input.GetAxis("LeftArm") >= 1 && Input.GetAxis("RightArm") <= 0)
            {
                _animator.SetFloat("AimHeldL", Input.GetAxis("LeftArm"));
                Characterbehaviourconfig.leftArm.Fire(transform, Characterbehaviourconfig.leftSpawn, Characterbehaviourconfig.leftdamager);
            }
            else
                _animator.SetFloat("AimHeldL", Input.GetAxis("LeftArm"));

            if (Input.GetAxis("RightArm") >= 1 && Input.GetAxis("LeftArm") <= 0)
            {
                _animator.SetFloat("AimHeldR", Input.GetAxis("RightArm"));
                Characterbehaviourconfig.rightArm.Fire(transform, Characterbehaviourconfig.rightSpawn, Characterbehaviourconfig.rightdamager);
            }
            else
                _animator.SetFloat("AimHeldR", Input.GetAxis("RightArm"));

            if (Input.GetButtonDown("Head"))
            {
                Debug.Log("Head Abillity not present!");
            }

            if (Input.GetButtonDown(DashButtonValue) && _dashing == false)   //  Dash Button
            {
                if (_charges >= 0)
                {
                    DashProjectionObjectA.transform.localPosition = new Vector3(0, 0, 0);
                    DashProjectionObjectB.transform.localPosition = new Vector3(0, 0, 0);
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


        #endregion

        #region Joystick2
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 1)
        {

            if (Input.GetAxis("LeftArmB") >= 1 && Input.GetAxis("RightArmB") <= 0)
            {
                _animator.SetFloat("AimHeldL", Input.GetAxis("LeftArmB"));
                Characterbehaviourconfig.leftArm.Fire(transform, Characterbehaviourconfig.leftSpawn, Characterbehaviourconfig.leftdamager);
            }
            else
                _animator.SetFloat("AimHeldL", Input.GetAxis("LeftArmB"));

            if (Input.GetAxis("RightArmB") >= 1 && Input.GetAxis("LeftArmB") <= 0)
            {
                _animator.SetFloat("AimHeldR", Input.GetAxis("RightArmB"));
                Characterbehaviourconfig.rightArm.Fire(transform, Characterbehaviourconfig.rightSpawn, Characterbehaviourconfig.rightdamager);
            }
            else
                _animator.SetFloat("AimHeldR", Input.GetAxis("RightArmB"));

            if (Input.GetButtonDown("HeadB"))
            {
                Debug.Log("Head Abillity not present!");
            }

            if (Input.GetButtonDown(DashBButtonValue) && _dashing == false)   //  Dash Button
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

        #endregion

        #region InputReliantAnimation
        if (_animator.GetFloat("AimHeldL") > 0)
            _animator.SetBool("AimDoneL", true);
        else if (_animator.GetFloat("AimHeldL") <= 0
            && _animator.GetBool("AimReleaseL") == false
            && _animator.GetBool("AimDoneL") == true)
        {
            _animator.SetBool("AimDoneL", false);
            _animator.SetBool("AimReleaseL", true);
        }
        else if (_animator.GetFloat("AimHeldL") == 0
            && _animator.GetBool("AimReleaseL") == true)
        {
            _animator.SetBool("AimReleaseL", false);
        }
        else
        {
            _animator.SetBool("AimDoneL", false);
            _animator.SetBool("AimReleaseL", false);
        }

        if (_animator.GetFloat("AimHeldR") > 0)
            _animator.SetBool("AimDoneR", true);
        else if (_animator.GetFloat("AimHeldR") == 0
            && _animator.GetBool("AimReleaseR") == false
            && _animator.GetBool("AimDoneR") == true)
        {
            _animator.SetBool("AimDoneR", false);
            _animator.SetBool("AimReleaseR", true);
        }
        else if (_animator.GetFloat("AimHeldR") == 0
            && _animator.GetBool("AimReleaseR") == true)
        {
            _animator.SetBool("AimReleaseR", false);
        }
        else
        {
            _animator.SetBool("AimDoneR", false);
            _animator.SetBool("AimReleaseR", false);
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
        if (m.x != 0 || m.z != 0)
            _animator.SetBool("Movement", true);
        else
            _animator.SetBool("Movement", false);
        transform.position += m;
    }

    #region Old Dash
    //  For dashing with the character
    //void Dash(float speed, int count, Vector3 Direction)
    //{
    //    Vector3 move = Direction * speed;
    //    _dashtime -= 1;
    //    transform.position += move;
    //    if (count == 0)
    //    {
    //        _dashing = false;
    //        _canmove = true;
    //    }
    //}
    #endregion

    // For moving the projection for the character forward  ***
    void DashProjection(float speed, int count, Vector3 Direction)
    {
        GameObject Projection = null;

        if (Controllerconfig.gamePadNum == 0)
            Projection = Instantiate(DashProjectionObjectA, gameObject.transform);
        else if (Controllerconfig.gamePadNum == 1)
            Projection = Instantiate(DashProjectionObjectB, gameObject.transform);
        else
        {
            Debug.Log("Set GamepadNum for character");
        }

        Vector3 move = Direction * speed;
        _dashtime -= 1;
        if (Projection != null)
            Projection.transform.position += move;
        if (count == 0)
        {
            _dashing = false;
            _canmove = true;
        }
        _checkReady = true;
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