using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;

public class GameAction : MonoBehaviour
{
    PointerEventData eventdata;

    [Header("���ԶԻ�")] public int dialogueID = 1000;

    
    private void Awake()
    {
        //��beginscene����ִ�� ���ɸ��ֵ��� Ȼ����ת��������
        //��Ϸ��ʼҪ���ĸ����� ���������ű��Ͳ�����
        //��һ�δ浵
        GameController.Instance.enabled = true;
        //GameSaveManger.Instance.SaveGameData();
        //LoadMainScene();
        //GameSaveManger.Instance.SaveGameData();

    }

    public void LoadMainScene()
    {
        //��ȡ��ʼ�浵

        print("ִ����");
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
