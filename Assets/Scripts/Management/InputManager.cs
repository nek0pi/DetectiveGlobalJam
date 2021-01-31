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

        if (Physics.Raycast(ray, out hit))
        {
            GetHoveredTag(hit);
            if (Input.GetMouseButtonDown(0))
                allInteractive?.Invoke(hit);

        }
        else
        {
            SetCommonCursor();
            if (Input.GetMouseButtonDown(0))
                allNonIneractive?.Invoke(Input.mousePosition);
        }
    }

    public void GetHoveredTag(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Use":
                CursorManager.Instance.ChangeCursor(CursorState.Use);
                break;
            case "Look":
                CursorManager.Instance.ChangeCursor(CursorState.Look);
                break;
            case "Speak":
                CursorManager.Instance.ChangeCursor(CursorState.Speak);
                break;
            default:
                CursorManager.Instance.ChangeCursor(CursorState.Common);
                break;

        }
    }

    public void SetCommonCursor()
    {
        CursorManager.Instance.ChangeCursor(CursorState.Common);
    }

}
