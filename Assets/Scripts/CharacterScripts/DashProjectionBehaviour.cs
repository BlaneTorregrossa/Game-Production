using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashProjectionBehaviour : MonoBehaviour
{
    public GameObject _characterObject;

    private CharacterControlsBehaviour _characterControlConfig;
    private float Countdown;
    private float CountdownMax;
    private bool ResetCountdown;

    void Start()
    {
        _characterControlConfig = transform.GetComponentInParent<CharacterControlsBehaviour>();
        CountdownMax = 1;
    }

    void Update()
    {
        if (Countdown <= 0)
        {
            _characterControlConfig.transform.position = transform.position;
            _characterControlConfig._checkReady = false;
            Destroy(gameObject);
        }

        if (Countdown > 0)
        {
            Countdown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_characterControlConfig._checkReady == false
            || _characterControlConfig._checkReady == true && other.tag != "Enviorment"
            || _characterControlConfig._checkReady == true && other.tag == "Character")
        {
            Destroy(gameObject);
            Debug.Log("Object in the way!");
        }
    }


}
