using UnityEngine;
using UnityEngine.Events;

public class DodikPerceptionZones : BasePerceptionZones
{
    public event UnityAction<GameObject> ObjectForSearchDetected;

    private ObjectType _currentObjectForSearch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_currentObjectForSearch.ToString()))
        {
            Debug.Log("Обнаружен искомый объект: " + other.gameObject.name);
            ObjectForSearchDetected?.Invoke(other.gameObject);
        }

        else if (other.gameObject.TryGetComponent<InterestingPlace>(out _))
        {
            Debug.Log("Точка интереса обнаружена: " + other.gameObject.name);
            InvokeInterestingDetectedAction(other.gameObject);
        }

        else if (other.gameObject.TryGetComponent<EnemyComponent>(out _))
        {
            Debug.Log("Обнаружена опасность: " + other.gameObject.name);
            InvokeDangerDetectedAction(other.gameObject);
        }
    }

    public void SetSearchObjectTag(ObjectType objectType)
    {
        Debug.Log("Текущий тег для поиска - " +  objectType.ToString());
        _currentObjectForSearch = objectType;
    }

    public ObjectType GetSearchObjectTag()
    {
        return _currentObjectForSearch;
    }
}
