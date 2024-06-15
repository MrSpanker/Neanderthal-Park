using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    [SerializeField] protected State _firstState;
    protected GameObject _target;
    protected State _currentState;

    private void Start()
    {
        ResetToStartState(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void ResetToStartState(State startState)
    {
        _currentState = startState;

        if (_currentState == null)
        {
            Debug.LogError("Не назначено начальное состояние в " + GetType().Name);
            return;
        }

        EnterToState(_currentState);

        Debug.Log("Перезагрузилась " + GetType().Name);
        Debug.Log(GetType().Name + " вошёл в " + _currentState.GetType().Name);
    }

    private void EnterToState(State state)
    {
        state.Enter(_target);
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

        EnterToState(_currentState);
        Debug.Log(GetType().Name + " вошёл в " + _currentState.GetType().Name);
    }
}
