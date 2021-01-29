using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : Singleton<SettingsManager>
{
    [SerializeField] private Vector2Int currentResolution;
    [SerializeField] private bool musicEnabled;
    [SerializeField] private bool soundEnabled;

    //Marta will add all checks tomorrow.
    public void SetResolution(Vector2Int newResolution, bool fullScreen = true)
    {
        if (newResolution != null)
        {
            Screen.SetResolution(newResolution.x, newResolution.y, fullScreen);
            SettingsManager.Instance.currentResolution = newResolution;
        }
    }

}
