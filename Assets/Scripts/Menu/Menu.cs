using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Menu")]
public class Menu : ScriptableObject
{
    public enum MenuType    //  The type of menu
    {
        MAINMENU = 0,
        PAUSEMENU = 1,
        CHARACTERCUSTOMIZATIONMENU = 2,
    }

    //public int MenuElements;    //  the amount of menu elements avalible
    public List<GameObject> ElementList;
    public MenuType Type;   //  The type of menu assigned to object
}
