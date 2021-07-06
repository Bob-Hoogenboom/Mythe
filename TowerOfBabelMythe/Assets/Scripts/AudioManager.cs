using UnityEngine;
using UnityEngine.Audio;
using SoundLibrary;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.isLooping;
        }
    }
    
    public void Play(Sounds name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log(s.ToString());
        if (s == null) return;
        s.source.Play();
    }

    public void Stop(Sounds name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Stop();
    }
}

namespace SoundLibrary
{
    public enum Sounds
    {
        Walk,
        Attack,
        GetHurt,
        RatScream,
        TowerCrumble,
        BGM,
        DoorOpen
    }
}
