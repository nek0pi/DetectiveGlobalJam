using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    [SerializeField] public int dialogIndex;
    public void Update()
    {
        //We need to get from Input Manager data of what User have clicked. 
        //Cast Ray from mouse position and check if something had been hitted and if it is our layer.
        //We will remove (or not) this part later when Input manager are done.

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactive"))
                {
                    CallDialogue(dialogIndex);
                    //Call here method from dialogue controller
                }
            }
        }
    }

    public abstract void CallDialogue(int index);

}
