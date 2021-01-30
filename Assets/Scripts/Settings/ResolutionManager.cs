using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Audio;

public class ResolutionManager : Singleton<ResolutionManager>
{
    [SerializeField] private Resolution currentResolution;
    public Resolution CurrentResolution { get { return currentResolution; } }
    //Marta will add all checks tomorrow.
    public void SetResolution(Vector2Int newResolution, bool isFullScreen = true)
    {
        if (newResolution != null)
        {
            Screen.SetResolution(newResolution.x, newResolution.y, isFullScreen);
            ResolutionManager.Instance.currentResolution.resolution = newResolution;
            ResolutionManager.Instance.currentResolution.isFullScreen = isFullScreen;
        }
    }

    
}

public struct Resolution
{
    public Vector2Int resolution;
    public bool isFullScreen;
}
