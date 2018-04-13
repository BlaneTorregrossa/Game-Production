using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehaviour : MonoBehaviour
{
    public Head HeadConfig;
	
	// Update is called once per frame
	void Update ()
    {
        //  Error in Unity when used ***
        if (Input.GetKeyDown("q"))
        {
            PerformHeadAbility();
        }
	}

    public void PerformHeadAbility()
    {
        if (HeadConfig.abilityType == Head.Ability.SHIELD)
        {
            ShieldActivate();
        }
        if(HeadConfig.abilityType == Head.Ability.LAZER)
        {
            LazerActivate();
        }
        else
        {
            Debug.Log("No Function set");
        }
    }

    private void ShieldActivate()
    {
        Debug.Log("Shield Activated");
    }

    private void LazerActivate()
    {
        Debug.Log("LazerActivated");
    }
}
