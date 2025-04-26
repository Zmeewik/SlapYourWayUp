using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //������ ������
    public Sound[] sounds;
    static public SoundManager instance;



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

        instance = this;
    }
    //������� ��������� ����������� �����
    public void VolumeChange(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.audiosource.volume = volume;
    }
    //��������� ����
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
    //���������� ����
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
    //��������� ���� �������
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
