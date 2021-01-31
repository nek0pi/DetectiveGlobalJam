using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void ShowADialogueWithBilly()
    {
        DialogueManager.Instance.StartDialogue(DialogueManager.Character.Tom, "FamilyPicture");
    }

    public void ShowADialogue2()
    {
        DialogueManager.Instance.StartDialogue(DialogueManager.Character.Tom, "BarDoor");
    }

    public void ShowVariablesInside()
    {
        Debug.Log(DialogueManager.Instance.dialogueRunner.variableStorage.GetValue("$checked_family_times"));
        ES3.Save("VariablesForDialogueRunner",DialogueManager.Instance.dialogueRunner.variableStorage.GetVariablesInside());

        DialogueManager.Instance.dialogueRunner.variableStorage.LoadVariablesInside(ES3.Load("VariablesForDialogueRunner") as Dictionary<string, Yarn.Value>);
    }
}
