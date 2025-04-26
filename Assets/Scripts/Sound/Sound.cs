using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioclip;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector]
    public AudioSource audiosource;
    public bool loop;
    public bool isMusic;
    public AudioMixerGroup OutputAudioMixerGroup;
}
