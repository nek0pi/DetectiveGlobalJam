using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer gameMixer;
    [SerializeField] string masterMixerName;
    [SerializeField] string soundMixerName;
    [SerializeField] string musicMixerName;

    AudioSettings audioSettings;
    public AudioSettings AudioSettings { get { return audioSettings; } }

    public void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);

        DontDestroyOnLoad(gameObject);
    }
    public void SetMixerVolume(MixerType mixer, float value)
    {
        switch (mixer)
        {
            case MixerType.Sound:
                var soundMixer = gameMixer.FindMatchingGroups(soundMixerName)[0].audioMixer;
                soundMixer.SetFloat("SoundVolume",value);
                audioSettings.soundVolume = value;
                break;
            case MixerType.Music:
                var musicMixer = gameMixer.FindMatchingGroups(musicMixerName)[0].audioMixer;
                musicMixer.SetFloat("MusicVolume", value);
                audioSettings.musicVolume = value;
                break;
            case MixerType.Master:
                var masterMixer = gameMixer.FindMatchingGroups(masterMixerName)[0].audioMixer;
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
                var soundMixer = gameMixer.FindMatchingGroups(soundMixerName)[0].audioMixer;
                soundMixer.GetFloat("SoundVolume", out volume);
                break;
            case MixerType.Music:
                var musicMixer = gameMixer.FindMatchingGroups(musicMixerName)[0].audioMixer;
                musicMixer.GetFloat("MusicVolume", out volume);
                break;
            case MixerType.Master:
                var masterMixer = gameMixer.FindMatchingGroups(masterMixerName)[0].audioMixer;
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

