using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTransition : Transition
{
    [SerializeField] private DodikPerceptionZones _dodikPerceptionZones;
    [SerializeField] private CollisionHandler _dodikCollisionHandler;

    protected override void OnEnable()
    {
        base.OnEnable();
        _dodikCollisionHandler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _dodikCollisionHandler.CollisionDetected -= OnCollisionDetected;
    }

    private void OnCollisionDetected(Collider other)
    {
        string otherTag = other.gameObject.tag;
        Debug.Log("Тег объекта: " + otherTag);

        if (other.CompareTag(_dodikPerceptionZones.GetSearchObjectTag().ToString()))
        {
            Debug.Log("Дошёл до: " + other.gameObject.name);
            NeedTransit = true;
        }
    }
}
