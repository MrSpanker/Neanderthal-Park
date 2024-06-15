using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchingState : State
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private float _wanderRadius = 30f;

    private Vector3 _targetPosition;
    private float _defaultSpeed;

    private void Start()
    {
        _targetPosition = GetRandomNavSphere(transform.position);

        MoveToTarget();
    }

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
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _targetPosition = GetRandomNavSphere(transform.position);
            MoveToTarget();
        }
    }

    private Vector3 GetRandomNavSphere(Vector3 origin)
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, _wanderRadius, NavMesh.AllAreas);

        return navHit.position;
    }

    private void MoveToTarget()
    {
        _agent.SetDestination(_targetPosition);
    }

    private void SetSpeed(float speed)
    {
        if (_agent != null)
        {
            _agent.speed = speed;
        }
    }
}
