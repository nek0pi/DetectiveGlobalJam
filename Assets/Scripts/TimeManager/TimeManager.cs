using System;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public float timeRemaining { get; set; }
    public Action onTimeOut;
    public TextMeshProUGUI textUI;

    public void ChangeTime(float time)
    {
        timeRemaining -= time;
        Mathf.Clamp(timeRemaining, 0, 100);
        if (timeRemaining == 0)
        {
            onTimeOut?.Invoke();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        textUI.text = timeRemaining.ToString("00");
    }
}