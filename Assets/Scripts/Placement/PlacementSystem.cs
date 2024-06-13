using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _mouseIndicator;
    [SerializeField] private GameObject _cellIndicator;
    [SerializeField] private PlacementInputManager _placementInputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private ObjectsDatabaseSO _objectsDatabaseSO;
    [SerializeField] private GameObject _gridVisualization;
    [SerializeField] private GridData _gridData;
    [SerializeField] private AudioSource _audioSource

    private Renderer _previewRenderer;

    private int _selectedObjectIndex = -1;

    private void Start()
    {
        StopPlacement();
        _gridData = new GridData();
        _previewRenderer = _cellIndicator.GetComponentInChildren<Renderer>();
    }

    private void StopPlacement()
    {
        _selectedObjectIndex = -1;
        _gridVisualization.SetActive(false);
        _cellIndicator.SetActive(false);
        _placementInputManager.OnClicked -= PlaceStructure;
        _placementInputManager.OnExit -= StopPlacement;
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        _selectedObjectIndex = _objectsDatabaseSO.ObjectsData.FindIndex(data => data.ID == ID);

        if(_selectedObjectIndex <0)
        {
            Debug.LogError($"No ID found {ID}");
            return;
        }

        _gridVisualization.SetActive(true);
        _cellIndicator.SetActive(true);
        _placementInputManager.OnClicked += PlaceStructure;
        _placementInputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if(_placementInputManager.IsPointerOverUI())
        {
            return;
        }



        Vector3 mousePosition = _placementInputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);


        GameObject newObject = Instantiate(_objectsDatabaseSO.ObjectsData[_selectedObjectIndex].Prefab);
        newObject.transform.position = _grid.CellToWorld(gridPosition);
    }

    private void Update()
    {
        if (_selectedObjectIndex < 0)
        {
            return;
        }

        Vector3 mousePosition = _placementInputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);
        _mouseIndicator.transform.position = mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(gridPosition);
    }
}
