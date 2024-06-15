using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodikStateMachine : BaseStateMachine
{

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
