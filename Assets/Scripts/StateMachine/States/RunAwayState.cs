using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAwayState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _fleeDistance;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private float _defaultSpeed;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (_agent != null && _agent.isOnNavMesh)
        {
            _defaultSpeed = _agent.speed;
            SetSpeed(_moveSpeed);
            _agent.isStopped = false;
        }

        _audioSource.PlayOneShot(_audioClip);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (_agent != null && _agent.isOnNavMesh)
        {
            SetSpeed(_defaultSpeed);
            _agent.isStopped = true;
            _agent.ResetPath();
        }
    }

    private void Update()
    {
        if (Target == null || _objectToMove == null)
        {
            SetSpeed(0f);
            return;
        }

            // Проверяем расстояние между текущим объектом и объектом, от которого нужно убегать (Target)
            if (Vector3.Distance(_objectToMove.position, Target.transform.position) < _fleeDistance)
        {
            // Вычисляем направление, в котором нужно убегать
            Vector3 fleeDirection = _objectToMove.position - Target.transform.position;

            // Находим пункт назначения, куда нужно убежать
            Vector3 fleeDestination = _objectToMove.position + fleeDirection.normalized * _fleeDistance;

            // Устанавливаем пункт назначения для навигационного агента
            _agent.SetDestination(fleeDestination);

            // Устанавливаем скорость движения, если необходимо
            SetSpeed(_moveSpeed);
        }
        else
        {
            // Если объект не в зоне опасности, останавливаем его
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
