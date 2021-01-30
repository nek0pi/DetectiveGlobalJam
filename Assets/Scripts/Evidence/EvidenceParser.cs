using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceParser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI partialDescriptionText;
    [SerializeField] TextMeshProUGUI fullDescriptionText;
    [SerializeField] Image imageHolder;
    [SerializeField] public Evidence evidenceInfo;

    private void Start()
    {
        ParseInfo();
    }

    private void ParseInfo()
    {
        if (evidenceInfo == null)
        {
            Debug.LogError(this + "There is no evidence info on this evidenceParser");
            return;
        }
        if(partialDescriptionText != null)
            partialDescriptionText.text = evidenceInfo.partialDescription;
        if(fullDescriptionText != null) 
            fullDescriptionText.text = evidenceInfo.fullDescription;
        if(imageHolder != null)
            imageHolder.sprite = evidenceInfo.image;
    }
}
