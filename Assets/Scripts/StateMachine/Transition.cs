using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    //public bool NeedTransit { get; protected set; }

    [SerializeField] private bool _needTransit;
    public bool NeedTransit
    {
        get => _needTransit;
        set => _needTransit = value;
    }

    public State TargetState => _targetState;
    [SerializeField] private State _targetState;
    protected GameObject Target { get; private set; }

    public void Init(GameObject target)
    {
        Target = target;
    }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}