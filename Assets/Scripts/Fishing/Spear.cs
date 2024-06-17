using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spear : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _splashAnimator;
    [SerializeField] private Fishing _fishing;

    public UnityEvent OnFishPearced;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        OnFishPearced?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _fishing.IsFishCaught == false)
        {
            _animator.SetTrigger("PiercingTrigger");
            _splashAnimator.SetTrigger("SplashTrigger");

        }
    }
}
