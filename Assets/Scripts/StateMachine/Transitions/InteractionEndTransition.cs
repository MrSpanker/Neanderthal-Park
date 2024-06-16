using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEndTransition : Transition
{
    [SerializeField] private InteractionWithObjectState _interactionWithObjectState;

    protected override void OnEnable()
    {
        base.OnEnable();
        _interactionWithObjectState.InteractionCompleted += OnInteractionCompleted;
    }

    private void OnDisable()
    {
        _interactionWithObjectState.InteractionCompleted -= OnInteractionCompleted;
    }

    private void OnInteractionCompleted()
    {
        NeedTransit = true;
    }
}
