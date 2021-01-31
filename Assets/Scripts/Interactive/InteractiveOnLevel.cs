using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveOnLevel : Interactive
{
    public DialogueManager.Character character;
    public string nameOfDialogueToCall;
    public override void CallDialogue()
    {
        if(nameOfDialogueToCall == null) return;
        DialogueManager.Instance.StartDialogue(character, nameOfDialogueToCall);
    }

    public override void CallOnInteract()
    {
        Debug.Log(gameObject.tag);
        CallDialogue();
    }
}
