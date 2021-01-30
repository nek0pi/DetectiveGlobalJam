using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] AudioMixer soundMixer;
    [SerializeField] AudioMixer musicMixer;

    AudioSettings audioSettings;
    public AudioSettings AudioSettings { get { return audioSettings; } }

    public void SetMixerVolume(MixerType mixer, float value)
    {
        switch (mixer)
        {
            case MixerType.Sound:
                soundMixer.SetFloat("SoundVolume",value);
                audioSettings.soundVolume = value;
                break;
            case MixerType.Music:
                musicMixer.SetFloat("MusicVolume", value);
                audioSettings.musicVolume = value;
                break;
            case MixerType.Master:
                masterMixer.SetFloat("MasterVolume", value);
                audioSettings.masterVolume = value;
                break;
        }
    }

    public float GetMixerVolume(MixerType mixer)
    {
        float volume = 0;
        switch (mixer)
        {
            case MixerType.Sound:
                soundMixer.GetFloat("SoundVolume", out volume);
                break;
            case MixerType.Music:
                musicMixer.GetFloat("MusicVolume", out volume);
                break;
            case MixerType.Master:
                masterMixer.GetFloat("MasterVolume", out volume);
                break;
        }

        return volume;
    }
}

public struct AudioSettings
{
    public float masterVolume;
    public float soundVolume;
    public float musicVolume;
}
public enum MixerType
{
    Master, Music, Sound
}

