using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EvidenceData", menuName = "ScriptableObjects/Create new evidence data", order = 1)]
public class Evidence : ScriptableObject
{
    public int id;
    public string partialDescription;
    public string fullDescription;
    public Sprite image;
    public EvidenceType type;
}

public enum EvidenceType
{ 
    Crutial, Secondary, Misleading 
}