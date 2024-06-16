using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] protected InteractionType InteractionType;

    public abstract void Interact();
    public InteractionType GetInteractionType()
    {
        return InteractionType;
    }
}

public enum InteractionType
{
    PickUp,
    Build
}