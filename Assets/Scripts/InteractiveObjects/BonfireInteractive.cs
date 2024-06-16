using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireInteractive : InteractiveObject
{
    [SerializeField] private AudioSource _audioSource;

    public override void Interact()
    {
        if (_audioSource.clip != null)
            _audioSource.Play();
        else
            Debug.LogWarning("На костёр не назначен звук при интеракции");
    }
}
