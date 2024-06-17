using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _rotation;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotation * Time.deltaTime));
    }
}
