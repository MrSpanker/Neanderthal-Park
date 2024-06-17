using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathways = new List<Transform>();
    [SerializeField] private float _speed;
    [SerializeField] private int _minChangeTargetTime;
    [SerializeField] private int _maxChangeTargetTime;

    private Transform _target;
    private float _time = 0f;
    private float _targetFocusTime = 0f;

    private void Start()
    {
        ChangeTarget();
    }

    private void ChangeTarget()
    {
        Transform newTarget = _pathways[Random.Range(0, _pathways.Count - 1)];

        while (newTarget == _target)
        {
            newTarget = _pathways[Random.Range(0, _pathways.Count - 1)];
        }

            _target = newTarget;
    }

    private void RefreshNextTargetFocusTime()
    {
        _targetFocusTime = Random.Range(_minChangeTargetTime, _maxChangeTargetTime);
    }

    private void TryChangeTarget()
    {
        _time += Time.deltaTime;

        if (_time > _targetFocusTime)
        {
            _time = 0;
            RefreshNextTargetFocusTime();
        }
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
        TryChangeTarget();
    }
}
