using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : Singleton<ProgressManager>
{
    private List<Evidence> availableEvidence { get; } = new List<Evidence>();
    public List<Evidence> CriticalEvidence { get; } = new List<Evidence>();
    public List<Evidence> AdditionalEvidence { get; } = new List<Evidence>();
    private List<ISubscriber> subscribers{ get; } = new List<ISubscriber>();

    private void Start()
    {
        var allEvidence = Resources.LoadAll<Evidence>("Assets/Resources/EvidenceData/");
        foreach (var ev in allEvidence)
        {
            Debug.Log(ev.partialDescription);
        }
    }
    

    public void AddCriticalEvidence(Evidence newEvidence)
    {
        if(newEvidence == null) return;
        
        CriticalEvidence.Add(newEvidence);
        NotifySubscribers(newEvidence);
    }
    
    public void RemoveCriticalEvidence(Evidence oldEvidence)
    {
        if (oldEvidence != null && CriticalEvidence.Contains(oldEvidence))
        {
            CriticalEvidence.Remove(oldEvidence);
        }
    }

    public void AddAdditionalEvidence(Evidence newAdditionalEvidence)
    {
        if(newAdditionalEvidence == null) return;
        
        AdditionalEvidence.Add(newAdditionalEvidence);
        NotifySubscribers(newAdditionalEvidence);
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


