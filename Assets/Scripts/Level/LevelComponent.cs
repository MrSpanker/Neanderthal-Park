using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    [SerializeField] private List<Zones> _zones = new();
}

[Serializable]
public class Zones
{
    public List<Transform> _pointsToExplore = new();

}