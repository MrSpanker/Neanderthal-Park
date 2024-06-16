using UnityEngine;

public class Scrimer : MonoBehaviour
{
    [SerializeField] float _timeDead;
    private void OnEnable()
    {
        Destroy(gameObject, _timeDead);
    }
}
