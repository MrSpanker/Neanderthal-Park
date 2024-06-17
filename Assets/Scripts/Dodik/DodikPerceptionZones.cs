using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DodikPerceptionZones : BasePerceptionZones
{
    public event UnityAction<GameObject> ObjectForSearchDetected;
    [SerializeField] private Collider[] _colliders;
    private ObjectType _currentObjectForSearch;
    private void Start()
    {
        StartCoroutine(CheckCollision());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InterestingPlace>(out _))
        {
            Debug.Log("����� �������� ����������: " + other.gameObject.name);
            InvokeInterestingDetectedAction(other.gameObject);
        }

        else if (other.gameObject.TryGetComponent<EnemyComponent>(out _))
        {
            Debug.Log("���������� ���������: " + other.gameObject.name);
            InvokeDangerDetectedAction(other.gameObject);
        }

        if (_currentObjectForSearch == ObjectType.Null)
        {
            Debug.Log("������� ��� ������ ���� �� ���������");
            return;
        }

        if (other.CompareTag(_currentObjectForSearch.ToString()))
        {
            Debug.Log("��������� ������� ������: " + other.gameObject.name);
            ObjectForSearchDetected?.Invoke(other.gameObject);
        }
    }
    public void SetSearchObjectTag(ObjectType objectType)
    {
        Debug.Log("������� ��� ��� ������ - " +  objectType.ToString());
        _currentObjectForSearch = objectType;
    }

    public ObjectType GetSearchObjectTag()
    {
        return _currentObjectForSearch;
    }
    IEnumerator CheckCollision()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = false;
        }
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = true;
        }
        StartCoroutine(CheckCollision());
    }
}
