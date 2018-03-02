using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// whole class needs a refactor
public class GetSpawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Character;


    void Start()
    {
    }

    public void moveToSpawn()
    {
        transform.position = SpawnPoint.transform.position;
    }

    public void MoveSpawnToCustomization()
    {
        SpawnPoint.transform.position = new Vector3(5000, 0, -4980);
    }

    public void MoveSpawnToArena()
    {
        SpawnPoint.transform.position = new Vector3(0, 5, -10);
    }
}
