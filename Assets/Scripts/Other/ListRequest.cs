using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListRequest : MonoBehaviour
{
    public List<GameObject> ListGO;

    public void AddList(GameObject newObject)
    {
        ListGO.Add(newObject);
        Debug.Log(ListGO.Count);
    }

    public void UseListAdd()
    {
        GameObject newObj = new GameObject();
        AddList(newObj);
    }


}
