using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(menuName = "GlobalGameManager")]
public class GlobalGameManager : ScriptableObject
{
    public void PrintInfo(string i)
    {
        Debug.Log(i);
    }
    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
