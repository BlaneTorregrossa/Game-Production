using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public Target TargetConfig;
    public float StartingHealth;

    private void Start()
    {
        if (StartingHealth == 0)
        {
            StartingHealth = 50;
        }
        TargetConfig.Health = StartingHealth;
        TargetConfig.Dead = false;
    }

    private void Update()
    {
        if (TargetConfig.Health <= 0)
        {
            TargetConfig.Dead = true;
        }
        if (TargetConfig.Dead == true)
        {
            Destroy(gameObject);
        }
    }
}
