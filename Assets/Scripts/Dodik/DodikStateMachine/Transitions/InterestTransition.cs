using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestTransition : Transition
{
    [SerializeField] private PerceptionZonesComponent _perceptionZones;
    [SerializeField] private BaseStateMachine _baseStateMachine;
    [SerializeField] private bool _fright = false;

    private void Start()
    {
        _perceptionZones.InterestingDetected += OnInterestingDetected;
    }

    private void OnDisable()
    {
        _perceptionZones.InterestingDetected -= OnInterestingDetected;
    }

    private void OnInterestingDetected(GameObject danger)
    {
        _baseStateMachine.ChangeTarget(danger);
        NeedTransit = true;
    }

    private void Update()
    {
        if (_fright)
        {
            _fright = false;
            NeedTransit = true;
        }
    }
}