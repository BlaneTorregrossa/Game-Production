using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObject : ScriptableObject
{
    public enum AnimationStates
    {
        Idle = 0,
        Aim = 1,
        Fire = 2,
        Melee = 3,
        Special = 4,
        Walk = 5,
        Hurt = 6,
        Death = 7,
    }

    public string AnimationName;
    public string AnimationDescription;
    public Animation CurrentAnimation;
    public AnimationStates State;
}
