using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private float _currentDistance;

    private void Update()
    {
        if (Target != null)
        {
            Vector3 currentPositionXZ = new(transform.position.x, 0, transform.position.z);
            Vector3 targetPositionXZ = new(Target.transform.position.x, 0, Target.transform.position.z);

            _currentDistance = Vector3.Distance(currentPositionXZ, targetPositionXZ);

            if (_currentDistance < _transitionRange)
                NeedTransit = true;
        }
    }
}
