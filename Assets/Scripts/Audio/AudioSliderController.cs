using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSliderController : MonoBehaviour
{
    [SerializeField] MixerType mixer;

    public void ChangeValue(float value)
    {
        AudioManager.Instance.SetMixerVolume(mixer, value);
    }
}
