using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private NavMeshAgent _agent;

    private float _defaultSpeed;

    private void OnEnable()
    {
        if (_agent != null)
        {
            _defaultSpeed = _agent.speed;
            SetSpeed(_speed);
        }
    }

    private void OnDisable()
    {
        if (_agent != null)
        {
            SetSpeed(_defaultSpeed);
        }
    }

    private void Update()
    {
        if (Target == null || _objectToMove == null || _agent == null || !_agent.isOnNavMesh) return;

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
