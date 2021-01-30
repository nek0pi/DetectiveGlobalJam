using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionUI : MonoBehaviour
{
    public void ChangeResolution(int index)
    {
        switch (index)
        {
            case 0:
                ResolutionManager.Instance.SetResolution(new Vector2Int(3840, 2160));
                break;
            case 1:
                ResolutionManager.Instance.SetResolution(new Vector2Int(1920, 1080));
                break;
            case 2:
                ResolutionManager.Instance.SetResolution(new Vector2Int(1280, 720));
                break;
            case 3:
                ResolutionManager.Instance.SetResolution(new Vector2Int(854, 480));
                break;
        }
    }

    public void SetFullscreen(bool state)
    {
        ResolutionManager.Instance.SetFullscreen(state);
    }
}
