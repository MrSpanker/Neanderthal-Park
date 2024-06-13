using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoizeTransform : MonoBehaviour
{
    private void OnEnable()
    {
        GetTransform();
    }
    public void GetTransform()
    {
        float y = Mathf.PerlinNoise(transform.position.x, transform.position.z);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
    //private void Update()
    //{
    //    GetTransform();
    //}
}
