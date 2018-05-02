using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public Target TargetConfig;

    private void Update()
    {
        if(TargetConfig.Health <= 0)
        {
            TargetConfig.Dead = true;
        }
        if(TargetConfig.Dead == true)
        {
            Destroy(gameObject);
        }
    }
}
