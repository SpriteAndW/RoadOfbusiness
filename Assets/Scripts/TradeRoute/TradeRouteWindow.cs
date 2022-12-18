using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TradeRouteWindow : UIFunctionWindow
{
    public MapsWindow mapsW;
    public OutTradeWindow outTW;
    public InTradeWindow inTW;
    protected override void Start()
    {
        // base.Start();
        GetUIeventhandler("Close").PointerClick += BackMainScene;
    }

    private void BackMainScene(PointerEventData eventData)
    {
        
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
        SceneManager.LoadScene("MainScene");
    }

    public void Maps()
    {
        mapsW.SetVisible(true);
    }

    public void OutTrade()
    {
        outTW.SetVisible(true);
        outTW.Refresh();
    }

    public void InTrade()
    {
        inTW.SetVisible(true);
        inTW.Refresh();
    }

    //public void BackMainScene()
    //{
    //    EventHandler.CallAfterSceneLoadeEvent("MainScene");
    //}
}
