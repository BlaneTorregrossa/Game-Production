using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Menu Element")]
public class MenuElement : ScriptableObject
{

    public enum ElementType
    {
        TEXT = 0,
        BUTTON = 1,
        IMAGE = 2,
    }

    public ElementType Type;
}
