using UnityEngine;

public class Water : MonoBehaviour
{
    void Update()
    {
        float y = Mathf.PerlinNoise(transform.position.x + Time.time, transform.position.z + Time.time);

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
