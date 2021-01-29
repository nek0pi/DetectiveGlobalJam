using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] AudioMixer soundMixer;
    [SerializeField] AudioMixer musicMixer;

    void SetMixerVolume(MixerType mixer, float value)
    {
        switch (mixer)
        {
            case MixerType.Sound:
                soundMixer.SetFloat("SoundVolume",value);
                break;
            case MixerType.Music:
                musicMixer.SetFloat("MusicVolume", value);
                break;
            case MixerType.Master:
                masterMixer.SetFloat("MasterVolume", value);
                break;
        }
    }
}

public enum MixerType
{
    Master, Music, Sound
}

