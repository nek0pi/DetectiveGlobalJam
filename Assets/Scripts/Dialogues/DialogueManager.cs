using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DialogueManager : Singleton<DialogueManager>
{
    public DialogueRunner dialogueRunner;
    private Dictionary<string, YarnProgram> allDialogues = new Dictionary<string, YarnProgram>();
    public TextMeshProUGUI speakerNameText;
    public enum Character
    {
        Annie,
        Pusher,
        Radal,
        Vendor,
        Tom,
        Mel,
        Paul,
        Kidnapper,
        Taxi,
        
    }
    public enum Language
    {
        EnglishUS,
        Russian
    }

    private void Start()
    {
        //todo potentially add here some jobs system to make the load async and fast
        var loadedDialogues = Resources.LoadAll<YarnProgram>("Dialogues/");
        foreach (var dialogue in loadedDialogues)
        {
            allDialogues.Add(dialogue.name, dialogue);
        }
        Debug.Log("All dialogues are loaded.");
        
        dialogueRunner.AddCommandHandler("SetSpeaker" , SetSpeakerName);
        dialogueRunner.AddCommandHandler("AddClue" , AddClueFromDialogue);
        dialogueRunner.AddCommandHandler("ReduceTime" , ReduceTime);
        dialogueRunner.AddCommandHandler("GoToScene" , GoToScene);
        dialogueRunner.AddCommandHandler("Loose" , LooseEverything);
    }

    private void LooseEverything(string[] parameters)
    {
        //todo loose screen
    }

    private void GoToScene(string[] parameters)
    {
        TransportManager.Locations targetLocation = (TransportManager.Locations) Int32.Parse(parameters[0]);
        LoadingManager.LoadLevel(targetLocation.ToString());
    }

    private void ReduceTime(string[] parameters)
    {
        if(Int32.Parse(parameters[0])  == 0) return;
        TimeManager.Instance.ReduceTime(Int32.Parse(parameters[0]) * 360);
    }


    public Language currentLanguage = Language.EnglishUS;
    
    /// <summary>
    /// String based trigger for dialogues.
    /// </summary>
    /// <param name="character"></param>
    /// <param name="dialogueNameToTrigger"></param>
    public void StartDialogue(Character character,string dialogueNameToTrigger)
    {
        Debug.Log(character.ToString());
        TriggerDialogue(character.ToString(), dialogueNameToTrigger);
    }

    private void TriggerDialogue(string characterName, string dialogueNameToTrigger)
    {
        dialogueRunner.Clear();
        dialogueRunner.Add(allDialogues[characterName]);
        dialogueRunner.StartDialogue(characterName + "." + dialogueNameToTrigger);
    }

    public void ChangeLanguage(Language lang)
    {
        switch (lang)
        {
            case Language.Russian:
                // todo switch to russian
                DialogueManager.Instance.currentLanguage = Language.Russian;
                break;
            case Language.EnglishUS:
                DialogueManager.Instance.currentLanguage = Language.EnglishUS;
                //todo switch to engl
                break;
            
        }
    }

    private void SetSpeakerName(string[] name)
    {
        if (name[0] == "Null")
        {
            speakerNameText.text = "";
            return;
        }
        speakerNameText.text = name[0];
    }
    private void AddClueFromDialogue(string[] parameters)
    {
        ProgressManager.Instance.AddEvidence(Int32.Parse(parameters[0]));
    }

    private void TransportPlayer(int locationId)
    {
        TransportManager.Instance.TransportPlayer(locationId);
    }

}
