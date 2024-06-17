using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneInteractive : InteractiveObject
{
    [SerializeField] private AudioSource _audioSource;

    public override void Interact()
    {
        _audioSource.Play();
        GameObject.Destroy(this.gameObject, 1);
    }
}
