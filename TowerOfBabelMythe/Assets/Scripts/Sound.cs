using UnityEngine;
using SoundLibrary;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public Sounds name;
    public bool isLooping;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}