using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void ShowADialogueWithBilly()
    {
        DialogueManager.Instance.StartDialogue(DialogueManager.Character.Billy, "Start");
    }
}
