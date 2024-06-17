using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private float _speed;
    [SerializeField] private Fishing _fishing;

    private void Update()
    {
        if (_fishing.IsFishCaught == false)
            transform.position = Vector2.Lerp(transform.position, _objectToFollow.position, _speed * Time.deltaTime);
    }
}
