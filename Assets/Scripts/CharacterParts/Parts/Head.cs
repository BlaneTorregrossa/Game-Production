using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parts/Head")]
public class Head : Part
{
    public enum Ability
    {
        SHIELD = 0,
        LAZER = 1
    }
    public Ability abilityType;
}