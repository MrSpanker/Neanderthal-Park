using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider), typeof(NavMeshAgent))]
public class EnemyComponent : MonoBehaviour
{
    private SphereCollider _collider;
    private Vector3 _target;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DodikComponent>(out DodikComponent _))
        {

        }
    }
}
