using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    [SerializeField] public int dialogIndex;

    public abstract void CallOnInteract();
    public abstract void CallDialogue();
}
