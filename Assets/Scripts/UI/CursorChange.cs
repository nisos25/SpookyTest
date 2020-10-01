using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D[] cursorSprite;

    void Start()
    {
        Cursor.SetCursor(cursorSprite[0],Vector2.zero,CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorSprite[1], Vector2.zero, CursorMode.ForceSoftware);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorSprite[0], Vector2.zero, CursorMode.ForceSoftware);
        }
        
    }
}
