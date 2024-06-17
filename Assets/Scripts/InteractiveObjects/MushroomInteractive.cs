using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomInteractive : InteractiveObject
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _eatMushroom;

    public override void Interact()
    {
        _audioSource.PlayOneShot(_eatMushroom);
        GameObject.Destroy(this.gameObject, 1f);
    }
}
