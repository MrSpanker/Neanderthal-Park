using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObjectState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;

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

        System.Random random = new();
        int randomNumber = random.Next(0, _audioClips.Count);
        _audioSource.PlayOneShot(_audioClips[randomNumber]);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        SetSpeed(_defaultSpeed);

        if (_agent != null && _agent.isOnNavMesh)
        {
            _agent.isStopped = true;
            _agent.ResetPath();
        }
    }

    private void Update()
    {
        if (Target == null || _agent == null || !_agent.isOnNavMesh) return;

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