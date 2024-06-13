using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    public List<Vector3> PointsToExplore = new();
    public List<Vector3> BranchPositions = new();
    public Vector3 BonfirePosition = new();
}