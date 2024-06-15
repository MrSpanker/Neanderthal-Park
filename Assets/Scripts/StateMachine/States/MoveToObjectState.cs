using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObjectState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private NavMeshAgent _agent;

    private float _defaultSpeed;

    private void OnEnable()
    {
        _defaultSpeed = _agent.speed;
        SetSpeed(_moveSpeed);
    }

    private void OnDisable()
    {
        SetSpeed(_defaultSpeed);
    }

    private void Update()
    {
        if (Target == null || _agent == null || !_agent.isOnNavMesh) return;

        _agent.isStopped = false;
        _agent.destination = Target.transform.position;
    }

    private void SetSpeed(float speed)
    {
        if (_agent != null)
        {
            _agent.speed = speed;
        }
    }
}
