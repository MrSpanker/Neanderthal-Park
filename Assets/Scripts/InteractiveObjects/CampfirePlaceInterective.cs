using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CampfirePlaceInterective : InteractiveObject
{
    [SerializeField] private GameObject _campfire;
    [SerializeField] private float _waitTime;

    private void Start()
    {
        _campfire.transform.localScale = Vector3.zero;
        _campfire.SetActive(false);
    }

    public override void Interact()
    {
        _campfire.SetActive(true);
        _campfire.transform.DOScale(new Vector3(1, 1, 1), _waitTime);
    }
}