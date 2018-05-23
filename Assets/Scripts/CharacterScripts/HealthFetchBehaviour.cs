using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFetchBehaviour : MonoBehaviour
{

    public Character CurrentCharacter;
    public List<GameObject> HealthBars;


    [SerializeField]
    private float Health;
    //[SerializeField]
    //private float HealthLow, HealthHigh;

    //  Change Health Bar based on remaining character Health
    void Update()
    {
        Health = CurrentCharacter.Health;

        for (int i = 0; i < HealthBars.Count; i++)
        {
            HealthBars[i].SetActive(false);
        }

        if (CurrentCharacter.Health > 91 && CurrentCharacter.Health <= 100)
            HealthBars[0].SetActive(true);
        if (CurrentCharacter.Health > 81 && CurrentCharacter.Health <= 90)
            HealthBars[1].SetActive(true);
        if (CurrentCharacter.Health > 71 && CurrentCharacter.Health <= 80)
            HealthBars[2].SetActive(true);
        if (CurrentCharacter.Health > 61 && CurrentCharacter.Health <= 70)
            HealthBars[3].SetActive(true);
        if (CurrentCharacter.Health > 51 && CurrentCharacter.Health <= 60)
            HealthBars[4].SetActive(true);
        if (CurrentCharacter.Health > 41 && CurrentCharacter.Health <= 50)
            HealthBars[5].SetActive(true);
        if (CurrentCharacter.Health > 31 && CurrentCharacter.Health <= 40)
            HealthBars[6].SetActive(true);
        if (CurrentCharacter.Health > 21 && CurrentCharacter.Health <= 30)
            HealthBars[7].SetActive(true);
        if (CurrentCharacter.Health > 11 && CurrentCharacter.Health <= 20)
            HealthBars[8].SetActive(true);
        if (CurrentCharacter.Health > 1 && CurrentCharacter.Health <= 10)
            HealthBars[9].SetActive(true);

    }
}
