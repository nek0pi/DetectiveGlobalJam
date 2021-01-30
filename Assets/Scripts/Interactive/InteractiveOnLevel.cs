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
            if (Vector3.Distance(transform.position, NewPlayerController.Instance.transform.position) > .3f)
            {
                NewPlayerController.Instance.MoveWorldSpaceCharacter(transform.position);
            }
            Debug.Log(gameObject.tag);
            CallDialogue(base.dialogIndex);
        }

    }
}
