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

    public void GoToScene(string name)  //  Switching scene by scene name
    {
        SceneManager.LoadScene(name);
    }

    public void GoToScene(int index)    // Switching scene by index from set scene order
    {
        SceneManager.LoadScene(index);
    }
}
