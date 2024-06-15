using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPreyTransition : Transition
{
    [SerializeField] private EnemyPerceptionZones _enemyPerceptionZones;
    [SerializeField] private BaseStateMachine _stateMachine;

    private void OnEnable()
    {
        _enemyPerceptionZones.InterestingDetected += OnInterestingDetected;
    }
    
    private void OnDisable()
    {
        _enemyPerceptionZones.InterestingDetected -= OnInterestingDetected;
    }

    private void OnInterestingDetected(GameObject gameObject)
    {
        _stateMachine.SetTarget(gameObject);
        NeedTransit = true;
    }
}
