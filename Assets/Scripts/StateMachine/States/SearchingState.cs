using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SearchingState : State
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private float _wanderRadius = 30f;
    [SerializeField] private float _minWaitTime = 1f;
    [SerializeField] private float _maxWaitTime = 5f;

    private Vector3 _targetPosition;
    private float _defaultSpeed;
    private bool _isWaiting = false;
    private Coroutine _waitAndMoveCoroutine;

    private void Start()
    {
        _defaultSpeed = _agent.speed;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (_agent != null && _agent.isOnNavMesh)
        {
            SetSpeed(_moveSpeed);
            _agent.isStopped = false;
            MoveToTarget();
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        SetSpeed(_defaultSpeed);

        if (_waitAndMoveCoroutine != null)
        {
            StopCoroutine(_waitAndMoveCoroutine);
            _waitAndMoveCoroutine = null;
        }

        _isWaiting = false;

        if (_agent != null && _agent.isOnNavMesh)
        {
            _agent.isStopped = true;
        }
    }

    private void Update()
    {
        if (!_isWaiting && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _waitAndMoveCoroutine = StartCoroutine(WaitAndMove());
        }
    }

    private IEnumerator WaitAndMove()
    {
        SetActiveForAnimation(false);
        _isWaiting = true;
        float waitTime = Random.Range(_minWaitTime, _maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        _targetPosition = GetRandomNavSphere(transform.position);
        MoveToTarget();
        _isWaiting = false;
        SetActiveForAnimation(true);
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
