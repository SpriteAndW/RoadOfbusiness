using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIFunctionWindow : UIWindows
{

    protected virtual void Start()
    {
        GetUIeventhandler("Close").PointerClick += Close;

    }

    private void Close(PointerEventData eventData)
    {
        SetVisible(false);
    }
}
