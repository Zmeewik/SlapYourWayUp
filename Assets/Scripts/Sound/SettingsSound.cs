using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsSound : MonoBehaviour
{
    AudioMixer audioMixer;
    SoundManager soundManager;

    //������� ��������� �����
    public void ChangeSoundVolume(float value)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(value) * 20);
    }

    //������� ��������� �����
    public void ChangeMusicVolume(float value)
    {
        soundManager.VolumeChange("Music", value);
    }
}
