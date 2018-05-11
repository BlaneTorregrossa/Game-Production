using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPhysicsTriggerEnterHandler
{
    void OnPhysicsTriggerEnterRaised(UnityEngine.Object[] args);
}
public class PreventFallThroughFloorBehaviour : MonoBehaviour, IPhysicsTriggerEnterHandler
{
    public void OnPhysicsTriggerEnterRaised(UnityEngine.Object[] args)
    {
        var triggervolume = args[0] as GameObject;
        var playerobject = args[1] as GameObject;
        if (playerobject != null)
        {
            playerobject.transform.position = playerobject.GetComponent<CharacterBehaviour>().character.StartingPos;
        }
    }

}
