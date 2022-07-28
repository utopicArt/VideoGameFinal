using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntero : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorHover;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, cursorMode);
    }

    public void OnPointerEnter()
    {
        Cursor.SetCursor(cursorHover, hotSpot, cursorMode);
    }

    public void OnPointerExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, cursorMode);
    }
}
