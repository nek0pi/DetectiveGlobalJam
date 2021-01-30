using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DialogueManager : Singleton<DialogueManager>
{
    public DialogueRunner dialogueRunner;
    private Dictionary<string, YarnProgram> allDialogues = new Dictionary<string, YarnProgram>();
    public enum Character
    {
        MrWolf,
        Mel,
        Billy,
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
    }

    public Language currentLanguage = Language.EnglishUS;
    
    /// <summary>
    /// String based trigger for dialogues.
    /// </summary>
    /// <param name="character"></param>
    /// <param name="dialogueNameToTrigger"></param>
    public void StartDialogue(Character character,string dialogueNameToTrigger)
    {
        switch (character)
        {
            case Character.Mel:
                TriggerDialogue("Mel", dialogueNameToTrigger);
                break;
            case Character.MrWolf:
                TriggerDialogue("Wolf", dialogueNameToTrigger);
                break;
            case Character.Billy:
                TriggerDialogue("Billy", dialogueNameToTrigger);
                break;
        }
    }

    private void TriggerDialogue(string characterName, string dialogueNameToTrigger)
    {
        if (dialogueRunner.yarnScripts.Contains(allDialogues[characterName]) == false)
            dialogueRunner.Add(allDialogues[characterName]);
        dialogueRunner.StartDialogue(characterName + "." + dialogueNameToTrigger);
        return;
    }

    public void ChangeLanguage(Language lang)
    {
        switch (lang)
        {
            case Language.Russian:
                // todo switch to russian
                break;
            case Language.EnglishUS:
                //todo switch to engl
                break;
            
        }
    }
}
