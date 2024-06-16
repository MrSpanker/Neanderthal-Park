using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerriesInteractive : InteractiveObject
{
    [SerializeField] private GameObject _berriesBush;
    [SerializeField] private GameObject _noBerriesBush;
    [SerializeField] private float _recoveryTime;

    private void Start()
    {
        SetActiveForBerries(true);
    }

    public override void Interact()
    {
        SetActiveForBerries(false);
        StartCoroutine(RecoverBerries());
    }

    private void SetActiveForBerries(bool active)
    {
        _noBerriesBush.SetActive(!active);
        _berriesBush.SetActive(active);
    }

    private IEnumerator RecoverBerries()
    {
        yield return new WaitForSeconds(_recoveryTime);
        SetActiveForBerries(true);
    }
}
