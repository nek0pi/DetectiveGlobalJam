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
        partialDescriptionText.text = evidenceInfo.partialDescription;
        fullDescriptionText.text = evidenceInfo.fullDescription;
        imageHolder.sprite = evidenceInfo.image;
    }
}
