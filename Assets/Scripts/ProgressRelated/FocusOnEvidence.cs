using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FocusOnEvidence : MonoBehaviour
{
    public GameObject FocusUI;
    public TextMeshProUGUI descriptionText;
    public Image displayImage;

    public void ShowEvidenceFocused(Evidence evidence)
    {
        FocusUI.SetActive(true);
        if (evidence.image == null)
        {
            FillInDescription(evidence);
        }
        else
        {
            FillInImage(evidence);
            
        }
    }

    public void HideEvidenceFocus()
    {
        FocusUI.SetActive(false);
    }

    private void FillInDescription(Evidence evidence)
    {
        descriptionText.text = evidence.fullDescription;
        descriptionText.gameObject.SetActive(true);
        displayImage.gameObject.SetActive(false);
        displayImage.sprite = null;
    }

    private void FillInImage(Evidence evidence)
    {
        displayImage.sprite = evidence.image;
        displayImage.gameObject.SetActive(true);
        descriptionText.text = "";
        descriptionText.gameObject.SetActive(false);
    }
}
