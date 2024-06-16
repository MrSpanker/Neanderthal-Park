using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAwayState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _fleeDistance;

    private float _defaultSpeed;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (_agent != null)
        {
            _defaultSpeed = _agent.speed;
            SetSpeed(_speed);
        }
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
        if (Target == null || _objectToMove == null) return;

        // ��������� ���������� ����� ������� �������� � ��������, �� �������� ����� ������� (Target)
        if (Vector3.Distance(_objectToMove.position, Target.transform.position) < _fleeDistance)
        {
            // ��������� �����������, � ������� ����� �������
            Vector3 fleeDirection = _objectToMove.position - Target.transform.position;

            // ������� ����� ����������, ���� ����� �������
            Vector3 fleeDestination = _objectToMove.position + fleeDirection.normalized * _fleeDistance;

            // ������������� ����� ���������� ��� �������������� ������
            _agent.SetDestination(fleeDestination);

            // ������������� �������� ��������, ���� ����������
            SetSpeed(_speed);
        }
        else
        {
            // ���� ������ �� � ���� ���������, ������������� ���
            SetSpeed(0f);
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
