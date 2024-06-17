using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterTileInteractive : InteractiveObject
{
    [SerializeField] private AudioSource _audioSource;

    public override void Interact()
    {
        if (_audioSource.clip != null)
            _audioSource.Play();
        else
            Debug.LogWarning("На воду не назначен звук при интеракции");
    }
}
