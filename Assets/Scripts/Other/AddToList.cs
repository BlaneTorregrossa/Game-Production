using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToList : MonoBehaviour
{
    public PrefabReplacement ListContainer;

    public void Start()
    {
        var startList = ListContainer.MapList;

        if (gameObject.name[0] == 'C' ||
            gameObject.name[0] == 'B' ||
            gameObject.name[0] == 'O' ||
            gameObject.name[0] == 'W')
        {
            ListContainer.MapList.Add(gameObject);
        }
        else
            Debug.Log(gameObject.name + " is Not a Valid Object!");
    }
}
