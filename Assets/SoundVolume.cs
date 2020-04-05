using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    public void ChangeMusicVolume(float sliderValue)
    {
        _audioMixerGroup.audioMixer.SetFloat("Ambient", Mathf.Log10(sliderValue) * 20);
    }

    public void ChangeSFXVolume(float sliderValue)
    {
        _audioMixerGroup.audioMixer.SetFloat("Explosion", Mathf.Log10(sliderValue) * 20);
    }
}
