using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //[SerializeField] private AudioSource _audioSource;
    [SerializeField] private Transform _camera;
    
    [Serializable]
    struct AudioParameters
    {
        public string AudioName;
        public AudioClip Clip;
        public float Volume;
    }

    [SerializeField] private AudioParameters[] _audios;
    
    public void PlaySfx(string sfxName)
    {
        // _audioSource.clip = clip;
        // _audioSource.Play();
        foreach (var audio in _audios)
        {
            if (audio.AudioName == sfxName)
            {
                AudioSource.PlayClipAtPoint(audio.Clip, _camera.position, audio.Volume);
            }
        }
    }
}
