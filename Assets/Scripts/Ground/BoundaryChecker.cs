using UnityEngine;

public class BoundaryChecker : MonoBehaviour
{
    [SerializeField] private Vector3 _areaCenter = Vector3.zero;
    [SerializeField] private Vector3 _areaSize = new Vector3(100f, 0f, 200f);
    [SerializeField] private Transform _dodik;
    [SerializeField] private GameObject _loseMenu;

    private float _minX;
    private float _maxX;
    private float _minZ;
    private float _maxZ;

    public Vector3 GetAreaCenter() => _areaCenter;
    public Vector3 GetAreaSize() => _areaSize;

    private void Start()
    {
        CalculateMinMaxBounds();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        CalculateMinMaxBounds();
    }
#endif

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_areaCenter, _areaSize);
    }

    private void CalculateMinMaxBounds()
    {
        _minX = _areaCenter.x - _areaSize.x / 2;
        _maxX = _areaCenter.x + _areaSize.x / 2;
        _minZ = _areaCenter.z - _areaSize.z / 2;
        _maxZ = _areaCenter.z + _areaSize.z / 2;
    }

    public bool IsObjectWithinBounds(Transform objectToCheck)
    {
        if (objectToCheck == null) return false;

        bool isWithinBounds = objectToCheck.position.x >= _minX && objectToCheck.position.x <= _maxX 
            && objectToCheck.position.z >= _minZ && objectToCheck.position.z <= _maxZ;

        return isWithinBounds;
    }
}
