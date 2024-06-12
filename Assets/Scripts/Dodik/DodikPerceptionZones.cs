using UnityEngine;

public class DodikPerceptionZones : BasePerceptionZones
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InterestingPlace>(out _))
        {
            Debug.Log("����� �������� ����������: " + other.gameObject.name);
            InvokeInterestingDetectedAction(other.gameObject);
        }

        else if (other.gameObject.TryGetComponent<EnemyComponent>(out _))
        {
            Debug.Log("���������� ���������: " + other.gameObject.name);
            InvokeDangerDetectedAction(other.gameObject);
        }
    }
}
