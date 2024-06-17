using Unity.VisualScripting;
using UnityEngine;

public class CameraPanController : MonoBehaviour
{
    [SerializeField] private float _borderSize = 1f;
    [SerializeField] private float _initialPanSpeed = 1f; 
    [SerializeField] private float _maxPanSpeed = 10f;
    [SerializeField] private float _accelerationTime = 2f; 
    [SerializeField] private BoundaryChecker _boundaryChecker;
    [SerializeField] private Vector3 _cameraPosition;
    [SerializeField] private GameObject _dodik;
#if UNITY_EDITOR
    [SerializeField] private bool _disableCameraMovement = false;
#endif

    private float _currentPanSpeed;
    private float _timeSinceStartedMoving;

    private void Start()
    {
        _currentPanSpeed = 0f;
        _timeSinceStartedMoving = 0f;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (_disableCameraMovement)
            return;
#endif
        UpdatePan();
        if (Input.GetKey(KeyCode.Space))
        {
            ToDodik();
        }
    }
    public void ToDodik()
    {
        transform.position = _dodik.transform.position + _cameraPosition;
    }
    private void UpdatePan()
    {
        Vector3 position = transform.position;
        bool isMoving = false;

        if (Input.mousePosition.y >= Screen.height - _borderSize || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            position.z += _currentPanSpeed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.mousePosition.y <= _borderSize || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            position.z -= _currentPanSpeed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.mousePosition.x >= Screen.width - _borderSize || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += _currentPanSpeed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.mousePosition.x <= _borderSize || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= _currentPanSpeed * Time.deltaTime;
            isMoving = true;
        }

        if (isMoving)
        {
            _timeSinceStartedMoving += Time.deltaTime;
            _currentPanSpeed = Mathf.Lerp(_initialPanSpeed, _maxPanSpeed, _timeSinceStartedMoving / _accelerationTime);
        }
        else
        {
            _timeSinceStartedMoving = 0f;
            _currentPanSpeed = 0f;
        }

        if (isMoving && _boundaryChecker != null && !_boundaryChecker.IsObjectWithinBounds(transform))
        {
            return;
        }

        position.x = Mathf.Clamp(position.x, _boundaryChecker.GetAreaCenter().x - _boundaryChecker.GetAreaSize().x / 2, 
            _boundaryChecker.GetAreaCenter().x + _boundaryChecker.GetAreaSize().x / 2);
        position.z = Mathf.Clamp(position.z, _boundaryChecker.GetAreaCenter().z - _boundaryChecker.GetAreaSize().z / 2,
            _boundaryChecker.GetAreaCenter().z + _boundaryChecker.GetAreaSize().z / 2);

        transform.position = position;
    }
}