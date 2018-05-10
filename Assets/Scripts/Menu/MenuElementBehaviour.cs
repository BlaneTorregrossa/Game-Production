using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuElementBehaviour : MonoBehaviour
{
    public MenuElement CurrentElement;

    void Start()
    {
        if (tag == "Button")
            CurrentElement.Type = MenuElement.ElementType.BUTTON;
        else if (tag == "Text")
            CurrentElement.Type = MenuElement.ElementType.TEXT;
        else if (tag == "Image")
            CurrentElement.Type = MenuElement.ElementType.IMAGE;
    }

}
