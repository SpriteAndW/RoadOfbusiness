using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : UIWindows
{
    public MessageText message;
    public static MessageWindow Instance;

    public void ShowMessage(string text)
    {
        SetVisible(true);
        message.ShowMessage(text);
        SetVisible(false, 1);
    }
    
    public void ShowMessage(string text, Sprite img)
    {
        SetVisible(true);
        message.ShowMessage(text, img);
        SetVisible(false, 1);
    }

    private void Start()
    {
        Instance = this;
    }
}
