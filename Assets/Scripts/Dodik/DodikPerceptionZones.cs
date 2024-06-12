using UnityEngine;

public class DodikPerceptionZones : BasePerceptionZones
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InterestingPlace>(out _))
        {
            Debug.Log("Точка интереса обнаружена: " + other.gameObject.name);
            InvokeInterestingDetectedAction(other.gameObject);
        }

        else if (other.gameObject.TryGetComponent<EnemyComponent>(out _))
        {
            Debug.Log("Обнаружена опасность: " + other.gameObject.name);
            InvokeDangerDetectedAction(other.gameObject);
        }
    }
}
