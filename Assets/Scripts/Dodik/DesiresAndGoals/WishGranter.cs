using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishGranter : MonoBehaviour
{
    [SerializeField] private WishQueue _desiresQueue;

    private Desire _currentWish;
    private Goal _currentGoal;
    private GameObject _currentTarget;

    private void Start()
    {
        StartFulfillingNewWish();
    }

    private void StartFulfillingNewWish()
    {
        _currentWish = _desiresQueue.GetNewWish();
        _currentGoal = _currentWish.GetNewGoal();
    }
}
