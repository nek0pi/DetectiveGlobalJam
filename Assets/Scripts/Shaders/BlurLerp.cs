using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurLerp : MonoBehaviour
{
    //TODO fix this. It doesn't work for Sprites
    public float blurspeed;
    private Material m;
    float t = 0f;
    public float maxNum = 20f;
    private void Awake()
    {
        m = GetComponent<Image>().material;
    }
    private void OnEnable()
    {
        m.SetFloat("_Radius", 0f);
        t = 0f;
    }
    void Update()
    {
        FadeIn();
    }
    void FadeIn()
    {
        float val = Mathf.Lerp(0, maxNum, t);
        if (val >= maxNum) return;
        t += blurspeed * Time.deltaTime;
        m.SetFloat("_Radius", val);
    }
}
