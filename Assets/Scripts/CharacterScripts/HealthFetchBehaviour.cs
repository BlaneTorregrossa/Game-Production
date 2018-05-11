using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFetchBehaviour : MonoBehaviour
{

    public CharacterBehaviour CurrentCharacter;
    public List<GameObject> HealthBars;


    [SerializeField]
    private float CharacterHealth;
    //[SerializeField]
    //private float HealthLow, HealthHigh;

    //  Change Health Bar based on remaining character Health
    void Update()
    {
        CharacterHealth = CurrentCharacter.characterHealth;

        for (int i = 0; i < HealthBars.Count; i++)
        {
            HealthBars[i].SetActive(false);
        }

        if (CurrentCharacter.characterHealth > 91 && CurrentCharacter.characterHealth <= 100)
            HealthBars[0].SetActive(true);
        if (CurrentCharacter.characterHealth > 81 && CurrentCharacter.characterHealth <= 90)
            HealthBars[1].SetActive(true);
        if (CurrentCharacter.characterHealth > 71 && CurrentCharacter.characterHealth <= 80)
            HealthBars[2].SetActive(true);
        if (CurrentCharacter.characterHealth > 61 && CurrentCharacter.characterHealth <= 70)
            HealthBars[3].SetActive(true);
        if (CurrentCharacter.characterHealth > 51 && CurrentCharacter.characterHealth <= 60)
            HealthBars[4].SetActive(true);
        if (CurrentCharacter.characterHealth > 41 && CurrentCharacter.characterHealth <= 50)
            HealthBars[5].SetActive(true);
        if (CurrentCharacter.characterHealth > 31 && CurrentCharacter.characterHealth <= 40)
            HealthBars[6].SetActive(true);
        if (CurrentCharacter.characterHealth > 21 && CurrentCharacter.characterHealth <= 30)
            HealthBars[7].SetActive(true);
        if (CurrentCharacter.characterHealth > 11 && CurrentCharacter.characterHealth <= 20)
            HealthBars[8].SetActive(true);
        if (CurrentCharacter.characterHealth > 1 && CurrentCharacter.characterHealth <= 10)
            HealthBars[9].SetActive(true);

        //  ***
        if (Input.GetKeyDown(KeyCode.T) == true)
        {
            CurrentCharacter.characterHealth -= 5;
        }
    }
}
