using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public abstract void CallOnInteract();
    public abstract void CallDialogue();
}
