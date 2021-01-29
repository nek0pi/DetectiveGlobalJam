using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Singleton<DeckManager>, ISubscriber
{
    public EvidenceParser[] referencedEvidenceObjects;
    
    void Start()
    {
        ProgressManager.Instance.AddSubscriber(this);
    }
    

    public void GetUpdate(int id)
    {
        switch (id)
        {
            
        }
    }
}
