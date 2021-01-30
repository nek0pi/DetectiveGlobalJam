using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    //Hz, maybe singletone is better.
    public static void SaveAudioSettings()
    {
        ES3.Save("AudioSettings", AudioManager.Instance.AudioSettings);
    }

    public static void SaveResolutionSettings()
    {
        ES3.Save("ResolutionSettings", ResolutionManager.Instance.CurrentResolution);
    }
}
