using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField] private PlacementInputManager _placementInputManager;
    [SerializeField] private float _previewOffset = 0.06f;
    [SerializeField] private GameObject _cellIndicator;
    [SerializeField] private Material _previewMaterialPrefab;
    [SerializeField] private Renderer _cellIndicatorRenderer;

    private GameObject _previewObject;
    private Material _previewMaterialInstance;

    private void Start()
    {
        _previewMaterialInstance = new Material(_previewMaterialPrefab);
        _cellIndicator.SetActive(false);
    }

    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        _previewObject = Instantiate(prefab);
        PreparePreview(_previewObject);
        PrepareIndicator(size);
        _cellIndicator.SetActive(true);
    }

    private void PrepareIndicator(Vector2Int size)
    {
        if (size.x > 0 || size.y > 0)
        {
            _cellIndicator.transform.localScale = new Vector3(size.x, 0.001f, size.y);

            _cellIndicatorRenderer.material.mainTextureScale = size;
        }
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = _previewObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = _previewMaterialInstance;
            }

            renderer.materials = materials;
        }
    }

    public void StopShowingPreview()
    {
        _cellIndicator.SetActive(false);
        Destroy(_previewObject);
    }

    public void UpdatePosition(Vector3 position, bool validity)
    {
        MovePreview(position);
        MoveCursor(position);
        ApplyFeedback(validity);


    }

    private void ApplyFeedback(bool validity)
    {
        Color color = validity ? Color.white : Color.red;
        color.a = 0.5f;
        _cellIndicatorRenderer.material.color = color;
        _previewMaterialInstance.color = color;
    }

    private void MoveCursor(Vector3 position)
    {
        _cellIndicator.transform.position = new Vector3( position.x, _placementInputManager.GetSelectedMapPosition().y, position.z);

    }

    private void MovePreview(Vector3 position)
    {
        _previewObject.transform.position = new Vector3(position.x, _placementInputManager.GetSelectedMapPosition().y + _previewOffset, position.z);
    }
}
