using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WentAbroadTransition : Transition
{
    [SerializeField] private CollisionHandler _collisionHandler;

    protected override void OnEnable()
    {
        base.OnEnable();
        _collisionHandler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollisionDetected;
    }

    private void OnCollisionDetected(Collider collider)
    {
        if (collider.gameObject.CompareTag("Border"))
        {
            NeedTransit = true;

        }
    }
}
