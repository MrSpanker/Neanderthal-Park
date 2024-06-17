using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementData : MonoBehaviour
{
    private Vector3Int _gridPosition;
    private PlacementSystem _placementSystem;

    private void OnDestroy()
    {
        _placementSystem.RemoveObject(_gridPosition);
    }

    public void GetGridPosition(Vector3Int gridPosition)
    {
        _gridPosition = gridPosition;
    }

    public void GetPlacementSystem(PlacementSystem placementSystem)
    {
        _placementSystem = placementSystem;
    }


}
