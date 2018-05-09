using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MenuElement")]
public class MenuElement : ScriptableObject
{

    public enum ElementType
    {
        CANVAS = 0,
        TEXT = 1,
        BUTTON = 2,
        IMAGE = 3,
        OTHER = 4,
    }

    public ElementType Type;
}
