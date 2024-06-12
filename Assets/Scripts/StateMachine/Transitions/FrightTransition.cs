using UnityEngine;

public class FrightTransition : Transition
{
    [SerializeField] private DodikPerceptionZones _perceptionZones;
    [SerializeField] private BaseStateMachine _stateMachine;
    [SerializeField] private bool _fright = false;

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
        _stateMachine.ChangeTarget(danger);
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