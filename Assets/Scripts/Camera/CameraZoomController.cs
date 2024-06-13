using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoomController : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 1000f;
    [SerializeField] private Vector2 _scrollLimit = new Vector2(5f, 15f);
    //[SerializeField] private Transform _miniMapTrapezoid;

    private Camera _camera = null;
    //private float _initialOrthographicSize;
    //private Vector3 _initialTrapezoidScale;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.fieldOfView = _scrollLimit.x;
        //_initialOrthographicSize = _camera.orthographicSize;
        //_initialTrapezoidScale = _miniMapTrapezoid.localScale;
    }

    private void Update()
    {
        UpdateZoom();
    }

    private void UpdateZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scroll = scroll * _scrollSpeed * Time.deltaTime;
        _camera.fieldOfView -= scroll;
        _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _scrollLimit.x, _scrollLimit.y);
        //_camera.orthographicSize -= scroll;
        //_camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _scrollLimit.x, _scrollLimit.y);
        //UpdateMiniMapTrapezoid();
    }

    //private void UpdateMiniMapTrapezoid()
    //{
    //    if (_miniMapTrapezoid != null)
    //    {
    //        float scale = _camera.orthographicSize / _initialOrthographicSize;
    //        _miniMapTrapezoid.localScale = new Vector3(
    //            _initialTrapezoidScale.x * scale,
    //            _initialTrapezoidScale.y * scale,
    //            _initialTrapezoidScale.z);
    //    }
    //}
}