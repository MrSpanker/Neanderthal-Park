using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;

    protected State _currentState;

    [SerializeField] protected State _firstState;
    [SerializeField] protected GameObject _target;

    public void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState == null)
        {
            Debug.LogError("Не назначено начальное состояние в " + GetType().Name);
            return;
        }

        _currentState.Enter(_target);

        Debug.Log("Перезагрузилась " + GetType().Name);
        Debug.Log(GetType().Name + " вошёл в " + _currentState.GetType().Name);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState == null)
        {
            Debug.LogError(GetType().Name + " не может отпределить следующее состояние");
            return;
        }

        _currentState.Enter(_target);
        Debug.Log(GetType().Name + " вошёл в " + _currentState.GetType().Name);
    }

    public void ChangeTarget(GameObject newTarget)
    {
        if (newTarget != null)
            _target = newTarget;
    }
}
