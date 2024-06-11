using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InterestingPlace : MonoBehaviour
{
    private SphereCollider _collider;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
    }
}
