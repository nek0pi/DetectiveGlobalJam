using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [HideInInspector] public Action<RaycastHit> allInteractive;
    [HideInInspector] public Action<Vector3> allNonIneractive;
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                allInteractive?.Invoke(hit);
            }
            else 
            {
                allNonIneractive?.Invoke(Input.mousePosition);
            }
            
        }

    }
}
