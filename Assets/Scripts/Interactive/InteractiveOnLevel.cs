using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveOnLevel : Interactive
{
    public override void CallDialogue(int index)
    {
      

    }

    public override void CallOnInteract()
    {
        Debug.Log(gameObject.tag);
        CallDialogue(base.dialogIndex);
    }
}
