using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : Singleton<DeckManager>, ISubscriber
{
    public EvidenceParser[] referencedEvidenceObjects;
    public GameObject boardObj;
    void Start()
    {
        ProgressManager.Instance.AddSubscriber(this);
    }
    

    public void GetUpdate(int id)
    {
        // If there is evidence parser with this evidence id - set it to active
        foreach (var evParser in referencedEvidenceObjects)
        {
            if (evParser.evidenceInfo.id == id)
            {
                evParser.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void HideShow()
    {
        boardObj.SetActive(!boardObj.activeSelf);
    }
}
