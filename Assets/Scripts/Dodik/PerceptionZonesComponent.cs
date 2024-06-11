using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PerceptionZonesComponent : MonoBehaviour
{
    [SerializeField] private Collider _hearingZone;
    [SerializeField] private Collider _visibilityZone;

    public event UnityAction<GameObject> DangerDetected;
    public event UnityAction<GameObject> InterestingDetected;

    private void OnCollisionEnter(Collision collision)
    {
        if (true) // Тут нужна логика для опасности
        {
            InterestingDetected?.Invoke(collision.gameObject);

        }
        else
        {
            DangerDetected?.Invoke(collision.gameObject);
        }
    }
}
