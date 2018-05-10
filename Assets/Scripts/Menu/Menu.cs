using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Menu")]
public class Menu : ScriptableObject
{
    public enum MenuType    //  The type of menu
    {
        STANDARD = 0,   //  Standard A to Z menu
        PAUSEMENU = 1,  //  A to Z Menu that allows switching GameModes via input (PVP -> MENU via Pausing)
        CHARACTERCUSTOMIZATIONMENU = 2, //  For Customizing character
        ENDGAME = 3,    //  For ENDGAME Menu Workaround for issues with STANDARD
        NOMENU = 255,   //  If No menu is needed
    }

    //public int MenuElements;    //  the amount of menu elements avalible
    public GameObject AssignedObject;   //  Assigned Menu GameObject
    public List<GameObject> MenuElementGameObjects; //  All of the menu element gameobjects avalible
    public List<MenuElement> MenuElements;  //  All of the menu elements avalible
    public List<Button> ButtonList;    //  All of the buttons avalible in this menu
    public List<Text> TextList;  //  All of the text avalble in this menu
    public List<Image> ImageList; //  All of the images avalible in this menu
    public MenuType Type;   //  The type of menu assigned to scriptableObject
}
