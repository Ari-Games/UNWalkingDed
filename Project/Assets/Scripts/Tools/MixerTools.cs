using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

[Serializable]
public class MixerTools
{
    [SerializeField] private AudioMixerGroup mixer;

    public void OnMusic() => mixer.audioMixer.SetFloat("VolumeOfMusic", 0);
    public void OffMusic() => mixer.audioMixer.SetFloat("VolumeOfMusic", -80);
    public void OnEffects() => mixer.audioMixer.SetFloat("VolumeOfEffects", 0);
    public void OffEffects() => mixer.audioMixer.SetFloat("VolumeOfEffects", -80);
    public void OnUI() => mixer.audioMixer.SetFloat("VolumeOfUI", 0);
    public void OffUI() => mixer.audioMixer.SetFloat("VolumeOfUI", -80);

    public void OffAll() => mixer.audioMixer.SetFloat("VolumeOfMaster", -80);
    public void OnAll() => mixer.audioMixer.SetFloat("VolumeOfMaster", 0);
    public void ChangeVolumeAll(float volume) => mixer.audioMixer.SetFloat("VolumeOfMaster", volume);
}
