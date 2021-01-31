using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgressManager : Singleton<ProgressManager>
{
    private Dictionary<int, Evidence> availableEvidence { get; } = new Dictionary<int, Evidence>();
    public List<Evidence> CriticalEvidence { get; } = new List<Evidence>();
    private List<ISubscriber> subscribers{ get; } = new List<ISubscriber>();

    private void Start()
    {
        var allEvidence = Resources.LoadAll<Evidence>("EvidenceData/");
        for (int i = 0; i < allEvidence.Length; i++)
        {
            availableEvidence.Add(allEvidence[i].id, allEvidence[i]); 
        }
    }
    

    public void AddEvidence(int id)
    {
        if(availableEvidence[id] == null) return;
        
        CriticalEvidence.Add(availableEvidence[id]);
        NotifySubscribers(availableEvidence[id]);
    }
    
    public void RemoveEvidence(int id)
    {
        if (availableEvidence[id] != null && CriticalEvidence.Contains(availableEvidence[id]))
        {
            CriticalEvidence.Remove(availableEvidence[id]);
        }
    }
    

    #region Observable Behavior

    public void AddSubscriber(ISubscriber sub)
    {
        if(sub != null && subscribers.Contains(sub) == false)
            subscribers.Add(sub);
    }

    public void RemoveSubscriber(ISubscriber sub)
    {
        if (sub != null && subscribers.Contains(sub))
            subscribers.Remove(sub);
    }

    private void NotifySubscribers(Evidence newEvidence)
    {
        foreach (var sub in subscribers)
        {
            sub.GetUpdate(newEvidence.id);
        }
    }

    #endregion
    
}


