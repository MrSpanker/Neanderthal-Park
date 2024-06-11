using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }
    
    protected GameObject Target { get; private set; }
    [SerializeField] private State _targetState;

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(GameObject target)
    {
        Target = target;
    }
}