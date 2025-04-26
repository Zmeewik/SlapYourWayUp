using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Массив звуков
    public Sound[] sounds;
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.audiosource = gameObject.AddComponent<AudioSource>();
            s.audiosource.clip = s.audioclip;
            s.audiosource.volume = s.volume;
            s.audiosource.loop = s.loop;
            s.audiosource.outputAudioMixerGroup = s.OutputAudioMixerGroup;
        }
    }
    //Сменить громкость конкретного звука
    public void VolumeChange(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.audiosource.volume = volume;
    }
    //Проиграть звук
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.audioclip == null)
            return;
        if (s.isMusic && PlayerPrefs.GetInt("Music") == 0)
            s.audiosource.Play();
        else if (PlayerPrefs.GetInt("Sound") == 0)
     
            s.audiosource.Play();
    }
    //Остановить звук
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.audioclip == null)
            return;
        if (s.isMusic && PlayerPrefs.GetInt("Music") == 0)
            s.audiosource.Pause();
        else if (PlayerPrefs.GetInt("Sound") == 0)
            s.audiosource.Pause();
    }
    //Проиграть звук сначала
    public void PlayFromStart(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.audioclip == null)
            return;
        if (s.isMusic && PlayerPrefs.GetInt("Music") == 0)
        {
            s.audiosource.Stop();
            s.audiosource.Play();
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {
            s.audiosource.Stop();
            s.audiosource.Play();
        }
    }
}
