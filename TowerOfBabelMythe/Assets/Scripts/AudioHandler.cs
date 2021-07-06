using UnityEngine;
using SoundLibrary;
using System.Collections;

namespace Assets.Scripts
{
    public class AudioHandler : MonoBehaviour
    {
        private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        private void Play(Sounds sound)
        {
            _audioManager.Play(sound);
        }
    }
}