using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementInputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _placementLayerMask;

    private Vector3 _lastPosition;

    public event Action OnClicked;
    public event Action OnExit;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray ray = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, _placementLayerMask))
        {
            _lastPosition = hit.point;
        }

        return _lastPosition;
    }

    public bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnExit?.Invoke();
        }
    }
}
