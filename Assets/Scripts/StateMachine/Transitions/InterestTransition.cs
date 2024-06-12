using UnityEngine;

public class InterestTransition : Transition
{
    [SerializeField] private BasePerceptionZones _perceptionZones;
    [SerializeField] private BaseStateMachine _stateMachine;

    private void Start()
    {
        _perceptionZones.InterestingDetected += OnInterestingDetected;
    }

    private void OnDisable()
    {
        _perceptionZones.InterestingDetected -= OnInterestingDetected;
    }

    private void OnInterestingDetected(GameObject interest)
    {
        _stateMachine.ChangeTarget(interest);
        NeedTransit = true;
    }
}