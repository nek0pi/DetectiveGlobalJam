using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ResolutionManager : MonoBehaviour
{
    public static ResolutionManager Instance;
    [SerializeField] private Resolution currentResolution;
    public Resolution CurrentResolution { get { return currentResolution; } }
    //Marta will add all checks tomorrow.
    public void SetResolution(Vector2Int newResolution)
    {
        if (newResolution != null)
        {
            Screen.SetResolution(newResolution.x, newResolution.y, Screen.fullScreen);
            ResolutionManager.Instance.currentResolution.resolution = newResolution;
        }
    }

    public void SetFullscreen(bool isFullScreen = true)
    {
        Screen.fullScreen = isFullScreen;
        ResolutionManager.Instance.currentResolution.isFullScreen = Screen.fullScreen;
    }

    public void Start()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

}

public struct Resolution
{
    public Vector2Int resolution;
    public bool isFullScreen;
}
