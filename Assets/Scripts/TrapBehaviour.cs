using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{

    public Trap currentTrap = new Trap();

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void ActivateTrap()
    {
        if (currentTrap.delay <= 0)
        {
            
        }
    }

    public void DealDamage()
    {
        //player health - currentTrap.trapDamage;
    }

    public void SetPlayerDamage()
    {

    }
}
