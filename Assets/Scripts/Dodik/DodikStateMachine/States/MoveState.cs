using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _objectToMove;

    private void Update()
    {
        if (Target == null || _objectToMove == null) return;

        Vector3 direction = (Target.transform.position - _objectToMove.position).normalized;
        Vector3 newPosition = _objectToMove.position + _speed * Time.deltaTime * direction;
        _objectToMove.position = newPosition;
    }
}
