using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private PlacementInputManager _placementInputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private ObjectsDatabaseSO _objectsDatabaseSO;
    [SerializeField] private GameObject _gridVisualization;
    [SerializeField] private GridData _floorData;
    [SerializeField] private GridData _itemsData;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _correctPlacement;
    [SerializeField] private AudioClip _wrongPlacement;
    [SerializeField] private PreviewSystem _previewSystem;

    private int _selectedObjectIndex = -1;
    private List<GameObject> _placedObjects = new List<GameObject>();
    private Vector3Int _lastDetectedPosition = Vector3Int.zero;

    private void Start()
    {
        StopPlacement();
        _floorData = new GridData();
        _itemsData = new GridData();
    }

    private void StopPlacement()
    {
        _selectedObjectIndex = -1;
        _gridVisualization.SetActive(false);
        _previewSystem.StopShowingPreview();
        _placementInputManager.OnClicked -= PlaceStructure;
        _placementInputManager.OnExit -= StopPlacement;
        _lastDetectedPosition = Vector3Int.zero;
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        _selectedObjectIndex = _objectsDatabaseSO.ObjectsData.FindIndex(data => data.ID == ID);

        if (_selectedObjectIndex < 0)
        {
            Debug.LogError($"No ID found {ID}");
            return;
        }

        _gridVisualization.SetActive(true);
        _previewSystem.StartShowingPlacementPreview(_objectsDatabaseSO.ObjectsData[_selectedObjectIndex].Prefab, _objectsDatabaseSO.ObjectsData[_selectedObjectIndex].Size);
        _placementInputManager.OnClicked += PlaceStructure;
        _placementInputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (_placementInputManager.IsPointerOverUI())
        {
            return;
        }

        Vector3 mousePosition = _placementInputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);

        bool placementValidity = CheckPlacementValidity(gridPosition, _selectedObjectIndex);

        if (placementValidity == false)
        {
            _audioSource.PlayOneShot(_wrongPlacement);
            return;
        }

        _audioSource.PlayOneShot(_correctPlacement);
        GameObject newObject = Instantiate(_objectsDatabaseSO.ObjectsData[_selectedObjectIndex].Prefab);
        newObject.transform.position = _grid.CellToWorld(gridPosition);
        newObject.transform.position = new Vector3(newObject.transform.position.x, mousePosition.y, newObject.transform.position.z);  // redacted
        _placedObjects.Add(newObject);
        GridData selectedData = _objectsDatabaseSO.ObjectsData[_selectedObjectIndex].ID == 0 ? _floorData : _itemsData;
        selectedData.AddObjectAt(gridPosition, _objectsDatabaseSO.ObjectsData[_selectedObjectIndex].Size, _objectsDatabaseSO.ObjectsData[_selectedObjectIndex].ID, _placedObjects.Count - 1);

        _previewSystem.UpdatePosition(_grid.CellToWorld(gridPosition), false);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = _objectsDatabaseSO.ObjectsData[selectedObjectIndex].ID == 0 ? _floorData : _itemsData;

        return selectedData.CanPlaceObjectAt(gridPosition, _objectsDatabaseSO.ObjectsData[selectedObjectIndex].Size);
    }

    private void Update()
    {
        if (_selectedObjectIndex < 0)
        {
            return;
        }

        Vector3 mousePosition = _placementInputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);

        if (_lastDetectedPosition != gridPosition)
        {
            bool placementValidity = CheckPlacementValidity(gridPosition, _selectedObjectIndex);

            //_mouseIndicator.transform.position = mousePosition;
            _previewSystem.UpdatePosition(_grid.CellToWorld(gridPosition), placementValidity);
            _lastDetectedPosition = gridPosition;
        }
    }
}
