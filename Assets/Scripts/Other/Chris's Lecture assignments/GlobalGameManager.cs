using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GlobalGameManager")]
public class GlobalGameManager : ScriptableObject
{
    public void PrintInfo(string i)
    {
        Debug.Log(i);
    }
}
