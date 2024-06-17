using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    Dictionary<Vector3Int, PlacementData> _placedObjects = new();

    public void AddObjectAt(Vector3Int gridPosition, Vector2Int objectSize, int ID, int placedObjectIndex)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex);

        foreach (var position in positionToOccupy)
        {
            if (_placedObjects.ContainsKey(position))
                throw new Exception($"Dictionary already contains this cell position {position}");

            _placedObjects[position] = data;
        }
    }

    internal int GetRepresentationIndex(Vector3Int gridPosition)
    {
        if (_placedObjects.ContainsKey(gridPosition) == false)
            return -1;
        return _placedObjects[gridPosition].PlacedObjectIndex;
    }

    private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> returnValues = new();

        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                returnValues.Add(gridPosition + new Vector3Int(x, 0, y));
            }
        }

        return returnValues;
    }

    public bool CanPlaceObjectAt(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);

        foreach (var position in positionToOccupy)
        {
            if (_placedObjects.ContainsKey(position))
                return false;
        }

        return true;
    }

    internal void RemoveObjectAt(Vector3Int gridPosition)
    {
        //foreach (var pos in _placedObjects[gridPosition]._occupiedPositions )
        {
            _placedObjects.Remove(gridPosition);
        }
    }
}
