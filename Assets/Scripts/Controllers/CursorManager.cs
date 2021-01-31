using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField] CursorState currentCursorState = CursorState.Common;
    [SerializeField] List <CursorInfo> cursors;

    CursorMode cursorMode = CursorMode.Auto;

    public void ChangeCursor(CursorState newCursorState)
    {
        Cursor.SetCursor(cursors[(int)newCursorState].cursorTexture, Vector2.zero, cursorMode);
    }
}
[Serializable]
public class CursorInfo
{
    public CursorState cursorState;
    public Texture2D cursorTexture;
}
public enum CursorState
{ 
    Common, Use, Look, Speak
}
