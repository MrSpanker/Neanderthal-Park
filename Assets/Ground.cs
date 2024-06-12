using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject cubePrefab; // Префаб куба

    public int width = 100;
    public int depth = 100;
    public float min;
    public float max;
    public float spacing = 1.1f;

    public List<GameObject> _objects = new List<GameObject>();

    [ContextMenu ("Create")]
    public void Create()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                Vector3 pos = new Vector3(x * spacing, Random.Range(min, max), z * spacing);
                //Vector3 pos = new Vector3(x * spacing, Mathf.PerlinNoise(x * spacing, z * spacing), z * spacing);
                GameObject newCube = Instantiate(cubePrefab, pos, Quaternion.identity);
                _objects.Add(newCube);
                newCube.transform.parent = transform; 
            }
        }
    }

    [ContextMenu("Delete")]
    public void Delete()
    {
        for(int x = 0; x < _objects.Count; x++)
        {
            _objects[x].SetActive(false);
        }
        _objects.Clear();
    }
}
