using System;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public float timeRemaining { get; set; } = 21600f;
    public TextMeshProUGUI textUI;

    private void Start()
    {
        UpdateUI();
    }
    
    public void ReduceTime(float time)
    {
        timeRemaining -= time;
        Mathf.Clamp(timeRemaining, 0, int.MaxValue);
        if (timeRemaining == 0)
        {
            CallWithThreads();
        }

        UpdateUI();
    }

    private void CallWithThreads()
    {
        
        //todo Double check the name for the dialogue to start
        DialogueManager.Instance.StartDialogue(DialogueManager.Character.Kidnapper, "Threads" );
    }

    private void UpdateUI()
    {
        var t = TimeSpan.FromSeconds(timeRemaining);
        textUI.text = $"{t.Hours:00}:{t.Minutes:00}";
    }
}