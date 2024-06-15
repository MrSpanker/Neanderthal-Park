using UnityEngine;
using UnityEngine.Events;

public class EnemyPerceptionZones : BasePerceptionZones
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("������ ����������: " + other.gameObject.name);
            InvokeInterestingDetectedAction(other.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject);

        }
    }
}