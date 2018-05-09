using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsBehaviour : MonoBehaviour
{
    public Character Characterconfig;   //  Assigning character
    public CharacterControls Controllerconfig;  //  Assigning controller
    public int _charges;    //  charages for dashing with character
    public int _recharge;   //  Number that ticks up until it hits a value before reseting and giving an additional charge
    public bool _canmove;   //  can character control movement
    public bool _dashing;   //  is the cahracter in the middle of a dash
    public int _dashtime;   //  Counter that ticks down while dash is active
    public int _dashduration;   //  How long the character can dash 
    public bool _paused;    //  if game is "Paused" based on controller input

    [SerializeField]
    GameLoopBehaviour GameLoopInstance; //  For a boolen to disable controls while wait timer is running if in PVP mode
    private Vector3 _movedirection; //  Vector3 Direction for moving the character
    private Vector3 _lookdirection; //  Vector3 Direction for where the character looks
    private Vector3 _dashdirection; //  Vector3 Direction for where the character is dashing
    private Quaternion _currentrot; //  Adjust character rotation
    private GameObject _object; //  useless variable. Ask cjwalle97
    [SerializeField]
    private Menu _menu; //  Menu object information ***
    private GameType.GameMode _mode;    //  Game Mode information   ***
    private Menu.MenuType _menuType;    //  Menu Type information   ***
    private bool _wait; //  waiting for timer

    // Use this for initialization
    void Start()
    {
        _canmove = true;    //  Disable movement while dashing
        _dashing = false;   //  if character is dashing
        _paused = false;    //  if pause input is given
        _dashtime = 0;  //  amount of time passed until a new dash charge is given
        _mode = GameLoopInstance.CurrentGameMode;   //  Assigning game mode
        _wait = GameLoopInstance.WaitForTimer;  //  Assigning boolen for if secondary timer is running
        _charges = Characterconfig.DashCharges; //  Setting charge amount
    }

    private void FixedUpdate()
    {
        _mode = GameLoopInstance.CurrentGameMode;   //  Assigning game mode
        _menu = GameLoopInstance.ActiveMenu;    //  Assinging current menu
        _menuType = _menu.Type; //  Assigning menu type
        _wait = GameLoopInstance.WaitForTimer;  //  set based on timer

        #region Joystick1
        //  if the controller is set to config 0 amd if the Game mode is PVP and if waiting is false:
        //  Two inputs given from (the right stick) determine where the character will look in the world
        //  And if the character is able to dash or move
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 0 && _menuType == Menu.MenuType.NOMENU)
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
        #endregion

        #region Joystick2
        //  if the controller is set to config 0 amd if the Game mode is PVP and if waiting is false:
        //  Two inputs given from (the right stick) determine where the character will look in the world
        //  And if the character is able to dash or move
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
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        _mode = GameLoopInstance.CurrentGameMode;   //  Assigning game mode
        _menu = GameLoopInstance.ActiveMenu;    //  Assining current menu
        _menuType = _menu.Type; //  Assigning menu type
        _wait = GameLoopInstance.WaitForTimer;  //  set based on timer

        #region Joystick 1
        #region PVP
        //  ***
        //  if the controller is set to config 0 amd if the Game mode is PVP and if waiting is false:
        //  Then the following inputs are read:
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 0 && _menuType == Menu.MenuType.NOMENU)
        {
            //  If Pause input is pressed then paused is enabled and the gameLoop pauses 
            //  vice versa if pressed again
            if (Input.GetButtonDown("Pause"))
            {
                if (_paused == false)
                {
                    _paused = true;
                    GameLoopInstance.GamePause = true;
                }
                else if (_paused == true)
                {
                    _paused = false;
                    GameLoopInstance.GamePause = false;
                }
            }

            //  If not paused then: Left Arm Attack
            if (Input.GetAxis("LeftArm") >= 1 && _paused == false)
            {
                Debug.Log("Left Arm Attack not present!");
            }

            //  If not paused: Right Arm Attack
            if (Input.GetAxis("RightArm") >= 1 && _paused == false)
            {
                Debug.Log("Right Arm Attack not present!");
            }

            //  If not Paused: Head Abillity
            if (Input.GetButtonDown("Head") && _paused == false)
            {
                Debug.Log("Head Abillity not present!");
            }

            // if not paused and dashing then if charges are greater than 0 then:
            //  enable the use of dashing and remove one charge as well as disable character movement controls
            if (Input.GetButtonDown("Dash") && _dashing == false && _paused == false)   //  Dash Button
            {
                if (_charges > 0)
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
            DashRecharge(200, Characterconfig.DashCharges); //  Recharge setting for this character
        }
        #endregion

        #region PVPENDSCREEN
        if (_mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 0
            && _menuType == Menu.MenuType.ENDGAME)
        {
            if(Input.GetButtonDown("Submit"))
            {
                GameLoopInstance.GGM.GoToScene("257.CharacterSelectTest");  //  *** Assign this to "Button"
                //GameLoopInstance.GGM.GoTOScene("0.MainMenu");
            }
        }
        #endregion

        #region PVPPAUSE
        //  ***
        //  if the gamemode is MENU and the controller conffig is set to 0 and the menu is the pause menu
        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 0
            && _menuType == Menu.MenuType.PAUSEMENU)
        {

            //  If Pause input is pressed then paused is enabled and the gameLoop pauses 
            //  vice versa if pressed again
            if (Input.GetButtonDown("Pause"))
            {
                if (_paused == false)
                {
                    _paused = true;
                    GameLoopInstance.GamePause = true;
                }
                else if (_paused == true)
                {
                    _paused = false;
                    GameLoopInstance.GamePause = false;
                };
            }
        }
        #endregion

        #region CharacterCustomiztion
        //  ***
        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 0
            && _menuType == Menu.MenuType.CHARACTERCUSTOMIZATIONMENU)
        {

        }
        #endregion
        #endregion

        #region Joystick2
        #region PVP
        if (_wait == false && _mode == GameType.GameMode.PVP && Controllerconfig.gamePadNum == 1)
        {
            if (Input.GetButtonDown("PauseB"))   //  Pause button
            {
                if (_paused == false)
                {
                    _paused = true;
                    GameLoopInstance.GamePause = true;
                }
                else if (_paused == true)
                {
                    _paused = false;
                    GameLoopInstance.GamePause = false;
                }
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
        #endregion

        #region PauseMENU
        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 1
            && _menuType == Menu.MenuType.PAUSEMENU)
        {
            if (Input.GetButtonDown("PauseB"))
            {
                if (_paused == false)
                {
                    _paused = true;
                    GameLoopInstance.GamePause = true;
                }
                else if (_paused == true)
                {
                    _paused = false;
                    GameLoopInstance.GamePause = false;
                }
            }
        }
        #endregion
        #region CharacterCustomization
        if (_mode == GameType.GameMode.MENU && Controllerconfig.gamePadNum == 1
            && _menuType == Menu.MenuType.CHARACTERCUSTOMIZATIONMENU)
        {

        }
        #endregion

        #endregion
    }

    //Returns a 3D Vector based axis based off the axis produced by the left analog stick/WASD keys
    void Move(float s)
    {
        float x = 0;
        float z = 0;

        //  Controller 1
        if (Controllerconfig.gamePadNum == 0)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        // Controller 2
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

    //  Dsh when called will mode object in direction at a given speed for a set amount of time
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

    //  Returns look direction
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

    //  Once recharge limit is met charges increases and recharge is reset to 0
    //  Does not recharge on time
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