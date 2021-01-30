using System;
using System.Collections;
using System.Collections.Generic;
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

    public string[] characterNames;
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
                dialogueRunner.Add(allDialogues["Mel"]);
                break;
            case Character.MrWolf:
                dialogueRunner.Add(allDialogues["Wolf"]);
                break;
            case Character.Billy:
                dialogueRunner.Add(allDialogues["Billy"]);
                break;
        }
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
