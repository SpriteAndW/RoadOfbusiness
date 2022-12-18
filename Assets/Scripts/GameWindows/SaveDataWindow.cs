using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;

public class SaveDataWindow : UIFunctionWindow
{
    public bool IsSave;
    GameAction gameAction;
    protected override void Start()
    {
        base.Start();
        GetUIeventhandler("SaveData1").PointerClick += SavaData1;
        GetUIeventhandler("SaveData2").PointerClick += SavaData2;
        GetUIeventhandler("SaveData3").PointerClick += SavaData3;
        gameAction = FindObjectOfType<GameAction>();
    }

    private void SavaData3(PointerEventData eventData)
    {
        if (IsSave)
        {
            GameSaveManger.Instance.SaveAllData(3);
            SetVisible(false);
            MessageWindow.Instance.ShowMessage("存档成功");
        }
        else
        {
            GameSaveManger.Instance.LoadAllSaveData(3);
            gameAction.LoadMainScene();
            SetVisible(false);
        }
        GameController.Instance.Refresh();
    }

    private void SavaData2(PointerEventData eventData)
    {
        if (IsSave)
        {
            GameSaveManger.Instance.SaveAllData(2);
            SetVisible(false);
            MessageWindow.Instance.ShowMessage("存档成功");
        }
        else
        {
            GameSaveManger.Instance.LoadAllSaveData(2);
            gameAction.LoadMainScene();
            SetVisible(false);
        }
        GameController.Instance.Refresh();
    }

    private void SavaData1(PointerEventData eventData)
    {
        if (IsSave)
        {
            GameSaveManger.Instance.SaveAllData(1);
            SetVisible(false);
            MessageWindow.Instance.ShowMessage("存档成功");
        }
        else
        {
            GameSaveManger.Instance.LoadAllSaveData(1);
            gameAction.LoadMainScene();
            SetVisible(false);
        }
        GameController.Instance.Refresh();
    }
}
