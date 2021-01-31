using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayDialogOnStart : MonoBehaviour
{
    public DialogueManager.Character character;
    public string nameOfDialogueToCall;
    void Start()
    {
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        if (nameOfDialogueToCall != null)
        DialogueManager.Instance.StartDialogue(character, nameOfDialogueToCall);
    }

}
