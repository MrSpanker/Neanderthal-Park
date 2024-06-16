using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] float _timeDead;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;

    private void OnEnable()
    {
        System.Random random = new();
        int randomNumber = random.Next(0, _audioClips.Count);
        _audioSource.PlayOneShot(_audioClips[randomNumber]);
        Destroy(gameObject, _timeDead);
    }
}
