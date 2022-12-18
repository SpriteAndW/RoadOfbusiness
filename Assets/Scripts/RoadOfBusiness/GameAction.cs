using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;

public class GameAction : MonoBehaviour
{
    PointerEventData eventdata;

    [Header("测试对话")] public int dialogueID = 1000;

    
    private void Awake()
    {
        //在beginscene里面执行 生成各种单例 然后跳转到主场景
        //游戏开始要做的各种事 做完后这个脚本就不用了
        //做一次存档
        GameController.Instance.enabled = true;
        //GameSaveManger.Instance.SaveGameData();
        //LoadMainScene();
        //GameSaveManger.Instance.SaveGameData();

    }

    public void LoadMainScene()
    {
        //读取初始存档

        print("执行了");
        GameController.Instance.Refresh();
        EventSystem eventsys = Object.FindObjectOfType<EventSystem>();
        eventdata = new PointerEventData(eventsys);
        MapWindows mapW = UIManger.Instance.Getwindows<MapWindows>();
        eventdata.pointerClick = mapW.transform.GetchildByname("MainScene").gameObject;
        mapW.LoadSceneByName(eventdata);
    }
    public void GameStart()
    {
        GameSaveManger.Instance.LoadAllSaveData(0);
        BankManager.Instance.saveRecordDetailList.savrRecordList.Clear();
        DialogueManager.instance.ShowDialogueOnDayID(dialogueID);
    }
}
