using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jam/NewDesireData")]
public class Desire : ScriptableObject
{
    [SerializeField] private List<Goal> _goalList = new();
}
