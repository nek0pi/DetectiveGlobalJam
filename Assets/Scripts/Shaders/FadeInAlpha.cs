using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAlpha : MonoBehaviour
{
    public float fadeInSpeed = 2f;
    public float maxNum = 0.8f;
    

    private void OnEnable()
    {
        var texture = GetComponent<Image>();
        texture.DOFade(maxNum, fadeInSpeed);
    }

}
