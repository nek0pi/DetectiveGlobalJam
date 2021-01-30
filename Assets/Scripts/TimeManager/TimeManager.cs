using System;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public float timeRemaining { get; set; } = 21600f;
    public Action onTimeOut;
    public TextMeshProUGUI textUI;

    private void Start()
    {
        UpdateUI();
    }
    
    public void ChangeTime(float time)
    {
        timeRemaining -= time;
        Mathf.Clamp(timeRemaining, 0, int.MaxValue);
        if (timeRemaining == 0)
        {
            onTimeOut?.Invoke();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        var t = TimeSpan.FromSeconds(timeRemaining);
        textUI.text = $"{t.Hours:00}:{t.Minutes:00}";
    }
}