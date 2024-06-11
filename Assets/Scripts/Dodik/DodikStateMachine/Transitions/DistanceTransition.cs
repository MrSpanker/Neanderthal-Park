using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _rangeSpread;
    private float _transirionRange;

    private void Start()
    {
        _transirionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Target != null && Vector2.Distance(transform.position, Target.transform.position) < _transirionRange)
            NeedTransit = true;
    }
}
