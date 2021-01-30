using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveOnLevel : Interactive
{
    public override void CallDialogue(int index)
    {
      

    }

    public override void OnHit(RaycastHit raycastHit)
    {
        if (raycastHit.collider.gameObject == gameObject)
        {
            Debug.Log(gameObject.tag);
            CallDialogue(base.dialogIndex);
        }

    }
}
