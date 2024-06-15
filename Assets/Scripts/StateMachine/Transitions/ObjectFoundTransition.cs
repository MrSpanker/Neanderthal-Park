using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFoundTransition : Transition
{
    [SerializeField] private DodikPerceptionZones _dodikPerceptionZones;
    [SerializeField] private DodikStateMachine _dodikStateMachine;

    private void OnEnable()
    {
        _dodikPerceptionZones.ObjectForSearchDetected += SetNeedTransit;
    }

    private void OnDisable()
    {
        _dodikPerceptionZones.ObjectForSearchDetected -= SetNeedTransit;
    }

    private void SetNeedTransit(GameObject target)
    {
        _dodikStateMachine.SetTarget(target);
        NeedTransit = true;
    }
}
