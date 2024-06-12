using UnityEngine;
using UnityEngine.Events;

public class EnemyPerceptionZones : BasePerceptionZones
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DodikComponent>(out _))
        {
            Debug.Log("����� �������� ����������: " + other.gameObject.name);
            InvokeInterestingDetectedAction(other.gameObject);
        }
    }
}