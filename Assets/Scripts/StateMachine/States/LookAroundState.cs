using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundState : State
{
    [SerializeField] float _waitingTime = 2f;

    private Coroutine _waitingCoroutine = null;

    private void Start()
    {
        if (_waitingCoroutine != null)
            StopCoroutine(_waitingCoroutine);
        _waitingCoroutine = StartCoroutine(WaitingCoroutine());
    }

    private IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(_waitingTime);
    }
}