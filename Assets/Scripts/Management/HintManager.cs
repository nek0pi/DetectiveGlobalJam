using System.Linq;

public class HintManager : Singleton<HintManager>
{
    public void GetHint()
    {
        if (ProgressManager.Instance.CriticalEvidence.Count == 0)
        {
            DialogueManager.Instance.StartDialogue(DialogueManager.Character.Paul,"Hint" + 0);
        }

        var countOfEvidences = ProgressManager.Instance.CriticalEvidence.Count;
        DialogueManager.Instance.StartDialogue(DialogueManager.Character.Paul, "Hint" + countOfEvidences);
    }
}