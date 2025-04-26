using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsSound : MonoBehaviour
{
    AudioMixer audioMixer;
    SoundManager soundManager;

    //Сменить громкость звука
    public void ChangeSoundVolume(float value)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(value) * 20);
    }

    //Сменить громкость звука
    public void ChangeMusicVolume(float value)
    {
        soundManager.VolumeChange("Music", value);
    }
}
