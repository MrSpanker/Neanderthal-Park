using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTransition : Transition
{
    [SerializeField] private DodikComponent _dodikComponent;

    private void Update()
    {
        if (_dodikComponent.IsSearching == true)
            NeedTransit = true;
    }

}
