using UnityEngine;
using UnityEngine.AI;

public class StrollState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private NavMeshAgent _agent;

    private float _defaultSpeed;

    private void OnEnable()
    {
        _defaultSpeed = _agent.speed;
        _agent.speed = _speed;
    }

    private void OnDisable()
    {
        _agent.speed = _defaultSpeed;
    }

    private void Update()
    {
        if (Target == null || _objectToMove == null) return;

        _agent.isStopped = false;
        _agent.destination = Target.transform.position;
    }
}
