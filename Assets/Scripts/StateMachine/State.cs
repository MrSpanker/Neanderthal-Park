using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected GameObject Target { get; set; }
    [SerializeField] protected List<Transition> _transitions;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected string _animationParameterName;

    protected virtual void OnEnable()
    {
        SetActiveForAnimation(true);
    }

    protected virtual void OnDisable()
    {
        SetActiveForAnimation(false);
    }

    protected void SetActiveForAnimation(bool acrive)
    {
        if (_animator != null)
            _animator.SetBool(_animationParameterName, acrive);
        else
            Debug.LogError("Animator не назначен.");
    }

    public void Enter(GameObject target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }
}