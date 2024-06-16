using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public event UnityAction<Collider> CollisionDetected;

    private void OnTriggerEnter(Collider other)
    {
        CollisionDetected?.Invoke(other);
    }
}
