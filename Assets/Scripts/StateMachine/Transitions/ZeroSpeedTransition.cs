using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZeroSpeedTransition : Transition
{
    [SerializeField] private NavMeshAgent _agent;

    private void Update()
    {
        if (_agent != null && _agent.speed <= 0.5)
            NeedTransit = true;
    }
}
