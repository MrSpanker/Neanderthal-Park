using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrollState : State
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private List<GameObject> _waypoints = new List<GameObject>();

    private float _defaultSpeed;
    private int _currentWaypointIndex = 0;

    private void OnEnable()
    {
        _defaultSpeed = _agent.speed;
        SetSpeed(_speed);
    }

    private void OnDisable()
    {
        SetSpeed(_defaultSpeed);
    }

    private void Start()
    {
        if (_waypoints.Count > 0)
        {
            Target = _waypoints[0];
            SetDestinationToCurrentWaypoint();
        }
    }

    private void Update()
    {
        if (_waypoints.Count == 0 || Target == null || _objectToMove == null) return;

        if (HasReachedWaypoint())
        {
            MoveToNextWaypoint();
            SetDestinationToCurrentWaypoint();
        }
    }

    private bool HasReachedWaypoint()
    {
        return !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance;
    }

    private void MoveToNextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex >= _waypoints.Count)
            _currentWaypointIndex = 0;

        Target = _waypoints[_currentWaypointIndex];
    }

    private void SetDestinationToCurrentWaypoint()
    {
        _agent.destination = Target.transform.position;
    }

    private void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
}
