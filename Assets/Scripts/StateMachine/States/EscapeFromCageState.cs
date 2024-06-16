using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class EscapeFromCageState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _fleeDistance;
    [SerializeField] private Transform _pointBehindPlayer;
    [SerializeField] private GameObject _loseMenu;

    private float _defaultSpeed;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (_agent != null)
        {
            _defaultSpeed = _agent.speed;
            SetSpeed(_speed);
            _agent.speed = _speed; // ”становка скорости агента сразу
            _agent.isStopped = false; // ”бедитьс€, что агент не остановлен
        }

        _loseMenu.SetActive(true);
        _loseMenu.transform.DOScale(new Vector3(1, 1, 1), 1);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (_agent != null)
        {
            SetSpeed(_defaultSpeed);
        }
    }

    private void Update()
    {
        if (_pointBehindPlayer == null || _objectToMove == null || _agent == null) return;

        if (Vector3.Distance(_objectToMove.position, _pointBehindPlayer.position) < _fleeDistance)
        {
            _pointBehindPlayer.parent = null;
            Vector3 fleeDirection = _objectToMove.position - _pointBehindPlayer.position;
            Vector3 fleeDestination = _objectToMove.position + fleeDirection.normalized * _fleeDistance;
            _agent.SetDestination(fleeDestination);
            SetSpeed(_speed);
        }
        else
        {
            // ≈сли агент достиг цели или далеко от нее, можно сделать что-то другое
            // Ќапример, перезадать цель или остановить агента
            // _agent.SetDestination(_pointBehindPlayer.position);
            // _agent.isStopped = true;
            // _agent.speed = 0f;
            // и т.д.
        }
    }

    private void SetSpeed(float speed)
    {
        if (_agent != null)
        {
            _agent.speed = speed;
        }
    }
}
