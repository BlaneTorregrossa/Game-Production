using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractor
{
    void Interaction_Set(IInteractable interactable);
    void Interaction_Release(IInteractable interactable);
}

public interface IInteractable
{
    void Interact(object token);
}