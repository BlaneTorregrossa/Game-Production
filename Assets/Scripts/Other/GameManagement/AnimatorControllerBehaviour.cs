using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerBehaviour : MonoBehaviour
{

    public AnimationObject CurrentState;
    public AnimationObject PreviousState;
    public AnimationObject NextState;
    public GameObject CurrentObject;

    [SerializeField]
    private Animator CurrentAnimator;
    [SerializeField]
    private Animation CurrentAnnimation;

    void Start()
    {
        CurrentAnimator = CurrentObject.GetComponent<Animator>();
        CurrentAnnimation = new Animation();
    }

    //  For Switching Animations based on states
    public AnimationObject SwitchToNextAnimation(AnimationObject NewState)
    {
        NextState.State = NewState.State;
        PreviousState.State = CurrentState.State;
        CurrentState.State = NextState.State;

        return CurrentState;
    }

}
