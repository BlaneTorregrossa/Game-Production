using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashProjectionBehaviour : MonoBehaviour
{
    public GameObject _characterObject;
    private CharacterControlsBehaviour _characterControlConfig;

    void OnAwake()
    {
        _characterControlConfig = transform.GetComponentInParent<CharacterControlsBehaviour>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enviorment" && _characterControlConfig._checkReady == true)
        {
            _characterControlConfig.transform.position = transform.position;
            _characterControlConfig._checkReady = false;
        }
        else if (_characterControlConfig._checkReady == false
            || _characterControlConfig._checkReady == true && other.tag == "Enviorment")
        {
            Debug.Log("Object in the way!");
        }
    }

}
