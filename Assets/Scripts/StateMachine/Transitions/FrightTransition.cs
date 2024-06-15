using UnityEngine;

public class FrightTransition : Transition
{
    [SerializeField] private DodikPerceptionZones _perceptionZones;
    [SerializeField] private DodikStateMachine _stateMachine;

    private void OnEnable()
    {
        _perceptionZones.DangerDetected += OnDangerDetected;
    }

    private void OnDisable()
    {
        _perceptionZones.DangerDetected -= OnDangerDetected;
    }

    private void OnDangerDetected(GameObject danger)
    {
        _stateMachine.SetTarget(danger);
        NeedTransit = true;
    }
}