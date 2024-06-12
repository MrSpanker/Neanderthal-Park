using UnityEngine;
using UnityEngine.Events;

public class BasePerceptionZones : MonoBehaviour
{
    [SerializeField] private Collider _hearingZone;
    [SerializeField] private Collider _visibilityZone;

    public event UnityAction<GameObject> DangerDetected;
    public event UnityAction<GameObject> InterestingDetected;

    protected void InvokeDangerDetectedAction(GameObject danger)
    {
        DangerDetected?.Invoke(danger);
    }

    protected void InvokeInterestingDetectedAction(GameObject interest)
    {
        InterestingDetected?.Invoke(interest);
    }
}
