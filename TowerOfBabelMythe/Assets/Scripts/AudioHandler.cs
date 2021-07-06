using UnityEngine;
using SoundLibrary;
using System.Collections;

namespace Assets.Scripts
{
    public class AudioHandler : MonoBehaviour
    {
        protected AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        protected void Play(Sounds sound)
        {
            _audioManager.Play(sound);
        }

        protected void Stop(Sounds sound)
        {
            _audioManager.Stop(sound);
        }
    }
}