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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InterestingPlace>(out _))
        {
            Debug.Log("Точка интереса обнаружена: " + other.gameObject.name);
            InterestingDetected?.Invoke(other.gameObject);
        }

        else 
        {
            Debug.Log("Обнаружена опасность: " + other.gameObject.name);
            DangerDetected?.Invoke(other.gameObject);
        }
    }
}
