using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Singleton<DeckManager>, ISubscriber
{
    public EvidenceParser[] referencedEvidenceObjects;
    
    void Awake()
    {
        ProgressManager.instance.AddSubscriber(this);
    }
    

    public void GetUpdate(int id)
    {
        switch (id)
        {
            
        }
    }
}

public class EvidenceParser
{
}
