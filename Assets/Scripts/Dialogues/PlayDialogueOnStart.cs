using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayDialogueOnStart : MonoBehaviour
{    
    public DialogueManager.Character character;
    public string nameOfDialogueToCall;

    // Start is called before the first frame update
    void Start()
    {
        if(nameOfDialogueToCall == null) return;
        DialogueManager.Instance.StartDialogue(character, nameOfDialogueToCall);
    }

}
