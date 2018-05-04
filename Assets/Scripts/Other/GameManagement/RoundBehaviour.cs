using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  To determine who which character wins the round 
public class RoundBehaviour : MonoBehaviour
{
    //  For deciding the winning and losing roundss
    public void GiveRound(CharacterBehaviour CharacterA, CharacterBehaviour CharacterB, List<Round> RoundList, int listSize)
    {
        if (RoundList.Count != listSize)
        {
            Round tempRound = ScriptableObject.CreateInstance<Round>(); //  The temp round to be added to the round list
            tempRound.name = "Round " + (RoundList.Count + 1).ToString();   //  Naming the round

            if (CharacterA.character.Health > CharacterB.character.Health)
            {
                tempRound.Result = Round.RoundResult.CHARACTERAWIN; //  The 1st character Set as winner of round
                RoundList.Add(tempRound);
            }

            else if (CharacterA.character.Health < CharacterB.character.Health)
            {
                tempRound.Result = Round.RoundResult.CHARACTERBWIN; //  The 2nd character set as winner of round
                RoundList.Add(tempRound);
            }
            return;
        }

        else if (RoundList.Count >= listSize)   //  In case the list is full and the function is still called
        {
            Debug.Log("RoundList is full: " + RoundList.ToString());
            return;
        }
    }

    //  Extends list if there is a tie
    public void Tie(CharacterBehaviour CharacterA, CharacterBehaviour CharacterB, List<Round> RoundList, int listSize)
    {
        if (RoundList.Count != listSize)
        {
            Round TempRound = ScriptableObject.CreateInstance<Round>();
            TempRound.name = "Round " + (RoundList.Count + 1).ToString();   //  Naming the round
            TempRound.Result = Round.RoundResult.DRAW;
            RoundList.Add(TempRound);
            return;
        }

        else
        {
            Debug.Log("RoundList is full: " + RoundList.ToString());
            return;
        }
    }
}
